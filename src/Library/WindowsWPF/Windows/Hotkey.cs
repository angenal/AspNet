using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media;

namespace System.Windows
{
    /// <summary>Hotkey class. must be instantiated in or after window has been loaded.</summary>
    public class Hotkey : IDisposable
    {
        public static int Register(HotkeyModifiers modifier, Hotkeys key, Window window, HotkeyPressedEventHandler handler, bool registerImmediately = true)
        {
            Hotkey hotkey = new Hotkey(modifier, key, window, registerImmediately);
            hotkey.HotkeyPressed += new EventHandler<HotkeyEventArgs>(handler);
            int id = hotkey.Id;
            hotkeys.Add(id, hotkey);
            return id;
        }
        public static bool Unregister(int id)
        {
            if (!hotkeys.TryGetValue(id, out Hotkey hotkey) || id != hotkey.Id) return false;
            hotkey.Dispose();
            return hotkeys.Remove(id);
        }
        static readonly Dictionary<int, Hotkey> hotkeys = new Dictionary<int, Hotkey>();
        public event EventHandler<HotkeyEventArgs> HotkeyPressed;
        protected virtual void OnHotkeyPressed(HotkeyInfo info) { HotkeyPressed?.Invoke(this, new HotkeyEventArgs(this, info)); }
        public HotkeyModifiers Modifier { get; private set; }
        public Hotkeys Key { get; set; }
        public int Id { get; private set; }
        private readonly IntPtr _hWnd;
        private bool _registered;
        public Hotkey(HotkeyModifiers modifier, Hotkeys key, Window window, bool registerImmediately = false)
        {
            if (window == null) throw new ArgumentException("You must provide a form or window to register the hotkey to.", "window");
            Modifier = modifier;
            Key = key;
            _hWnd = new WindowInteropHelper(window).Handle;
            Id = GetHashCode();
            HookWndProc(window);
            if (registerImmediately) Register();
        }
        private void HookWndProc(Visual window)
        {
            var source = PresentationSource.FromVisual(window) as HwndSource;
            if (source == null) throw new HotkeyException("Could not create hWnd source from window.");
            source.AddHook(WndProc);
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            var info = HotkeyInfo.GetFromMessage(msg, lParam);
            if (info != null && info.Key == Key && info.Modifier == Modifier) OnHotkeyPressed(info);
            return IntPtr.Zero;
        }
        public void Register()
        {
            if (_registered) return;
            _registered = HotkeyRef.RegisterHotKey(_hWnd, Id, (uint)Modifier, (uint)Key);
            //if (!_registered) throw new HotkeyException($"Hotkey`{Key}` failed to register.");
            //_registered = true;
        }
        public void Unregister()
        {
            if (!_registered) return;
            if (!HotkeyRef.UnregisterHotKey(_hWnd, Id))
            {
                //Win32Exception wex = new Win32Exception();
                //if (wex.NativeErrorCode != 0) throw new HotkeyException($"Hotkey`{Key}` failed to unregister. See InnerException for details.", wex);
            }
            _registered = false;
        }
        public sealed override int GetHashCode()
        {
            return (int)Modifier ^ (int)Key ^ _hWnd.ToInt32();
        }
        public void Dispose()
        {
            Unregister();
            GC.SuppressFinalize(this);
        }
        ~Hotkey() { Unregister(); }
    }
    /// <summary></summary>
    [Serializable]
    public delegate void HotkeyPressedEventHandler(object sender, HotkeyEventArgs e);
    /// <summary></summary>
    public class HotkeyEventArgs : EventArgs
    {
        public HotkeyInfo HotkeyInfo { get; private set; }
        public Hotkey Hotkey { get; private set; }
        public HotkeyEventArgs(Hotkey hotkey, HotkeyInfo info)
        {
            HotkeyInfo = info;
            Hotkey = hotkey;
        }
    }
    /// <summary></summary>
    public class HotkeyException : Exception
    {
        public HotkeyException(string message) : base(message) { }
        public HotkeyException(string message, Exception inner) : base(message, inner) { }
    }
    /// <summary></summary>
    public class HotkeyInfo
    {
        public Hotkeys Key { get; private set; }
        public HotkeyModifiers Modifier { get; private set; }
        private HotkeyInfo(IntPtr lParam)
        {
            int lpInt = (int)lParam;
            Key = (Hotkeys)((lpInt >> 16) & 0xFFFF);
            Modifier = (HotkeyModifiers)(lpInt & 0xFFFF);
        }
        public static HotkeyInfo GetFromMessage(int msg, IntPtr lParam)
        {
            return !IsHotkeyMessage(msg) ? null : new HotkeyInfo(lParam);
        }
        public static bool IsHotkeyMessage(int m)
        {
            return m == HotkeyRef.WM_HOTKEY_MSG_ID;
        }
    }
    /// <summary></summary>
    public class HotkeyRef
    {
        /// <summary></summary>
        public const int WM_HOTKEY_MSG_ID = 0x0312;
        /// <summary>注册热键</summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="id">热键的ID值，用于跟踪管理此热键</param>
        /// <param name="fsModifiers">修饰键，Alt、Shift、Ctrl和Windows键</param>
        /// <param name="vk">某个字母键</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);
        /// <summary>取消注册热键</summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="id">注册热键时的ID值</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// <para>
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-sendinput"/>
        /// </para>
        /// </summary>
        /// <param name="cInputs">
        /// The number of structures in the <paramref name="pInputs"/> array.
        /// </param>
        /// <param name="pInputs">
        /// An array of <see cref="INPUT"/> structures.
        /// Each structure represents an event to be inserted into the keyboard or mouse input stream.
        /// </param>
        /// <param name="cbSize">
        /// The size, in bytes, of an <see cref="INPUT"/> structure.
        /// If <paramref name="cbSize"/> is not the size of an <see cref="INPUT"/> structure, the function fails.
        /// </param>
        /// <returns>
        /// The function returns the number of events that it successfully inserted into the keyboard or mouse input stream.
        /// If the function returns zero, the input was already blocked by another thread.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendInput", ExactSpelling = true, SetLastError = true)]
        public static extern uint SendInput([In] uint cInputs, [MarshalAs(UnmanagedType.LPArray)][In] INPUT[] pInputs, [In] int cbSize);
        /// <summary>
        /// <para>
        /// Places (posts) a message in the message queue associated with the thread that created the specified window and
        /// returns without waiting for the thread to process the message.
        ///</para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-postmessagew"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure is to receive the message. The following values have special meanings.
        /// </param>
        /// <param name="msg">
        /// The message to be posted.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is true.
        /// If the function fails, the return value is false.
        /// To get extended error information, call GetLastError.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "PostMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern bool PostMessage([In] IntPtr hWnd, [In] uint msg, [In] IntPtr wParam, [In] IntPtr lParam);
        /// <summary>
        /// <para>
        /// Sends the specified message to a window or windows.
        /// The <see cref="SendMessage"/> function calls the window procedure for the specified window
        /// and does not return until the window procedure has processed the message.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-sendmessage"/>
        /// </para>
        /// </summary>
        /// <param name="hWnd">
        /// A handle to the window whose window procedure will receive the message.
        /// </param>
        /// <param name="Msg">
        /// The message to be sent.
        /// </param>
        /// <param name="wParam">
        /// Additional message-specific information.
        /// </param>
        /// <param name="lParam">
        /// Additional message-specific information.
        /// </param>
        /// <returns>
        /// The return value specifies the result of the message processing; it depends on the message sent.
        /// </returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessageW", ExactSpelling = true, SetLastError = true)]
        public static extern int SendMessage([In] IntPtr hWnd, [In] uint Msg, [In] IntPtr wParam, [In] IntPtr lParam);
    }

    /// <summary></summary>
    [Flags]
    public enum HotkeyModifiers
    {
        NoMod = 0x0000,
        Alt = 0x0001,
        Ctrl = 0x0002,
        Shift = 0x0004,
        Win = 0x0008
    }
    /// <summary>Copy of System.Windows.Forms.Keys, remove the requirement to include a reference to System.Windows.Forms</summary>
    [Flags]
    public enum Hotkeys
    {
        Modifiers = -65536,
        None = 0,
        LButton = 1,
        RButton = 2,
        Cancel = RButton | LButton,
        MButton = 4,
        XButton1 = MButton | LButton,
        XButton2 = MButton | RButton,
        Back = 8,
        Tab = Back | LButton,
        LineFeed = Back | RButton,
        Clear = Back | MButton,
        Enter = Clear | Tab,
        Return = Enter,
        ShiftKey = 16,
        ControlKey = ShiftKey | LButton,
        Menu = ShiftKey | RButton,
        Pause = Menu | ControlKey,
        Capital = ShiftKey | MButton,
        CapsLock = Capital,
        HanguelMode = CapsLock | ControlKey,
        HangulMode = HanguelMode,
        KanaMode = HangulMode,
        JunjaMode = KanaMode | Pause,
        FinalMode = ShiftKey | Back,
        HanjaMode = FinalMode | ControlKey,
        KanjiMode = HanjaMode,
        Escape = KanjiMode | Pause,
        IMEConvert = FinalMode | CapsLock,
        IMENonconvert = IMEConvert | KanjiMode,
        IMEAccept = IMEConvert | Menu,
        IMEAceept = IMEAccept,
        IMEModeChange = IMEAceept | IMENonconvert,
        Space = 32,
        PageUp = Space | LButton,
        Prior = PageUp,
        Next = Space | RButton,
        PageDown = Next,
        End = PageDown | Prior,
        Home = Space | MButton,
        Left = Home | Prior,
        Up = Home | PageDown,
        Right = Up | Left,
        Down = Space | Back,
        Select = Down | Prior,
        Print = Down | PageDown,
        Execute = Print | Select,
        PrintScreen = Down | Home,
        Snapshot = PrintScreen,
        Insert = Snapshot | Select,
        Delete = Snapshot | Print,
        Help = Delete | Insert,
        D0 = Space | ShiftKey,
        D1 = D0 | Prior,
        D2 = D0 | PageDown,
        D3 = D2 | D1,
        D4 = D0 | Home,
        D5 = D4 | D1,
        D6 = D4 | D2,
        D7 = D6 | D5,
        D8 = D0 | Down,
        D9 = D8 | D1,
        A = 65,
        B = 66,
        C = B | A,
        D = 68,
        E = D | A,
        F = D | B,
        G = F | E,
        H = 72,
        I = H | A,
        J = H | B,
        K = J | I,
        L = H | D,
        M = L | I,
        N = L | J,
        O = N | M,
        P = 80,
        Q = P | A,
        R = P | B,
        S = R | Q,
        T = P | D,
        U = T | Q,
        V = T | R,
        W = V | U,
        X = P | H,
        Y = X | Q,
        Z = X | R,
        LWin = Z | Y,
        RWin = X | T,
        Apps = RWin | Y,
        Sleep = Apps | LWin,
        NumPad0 = 96,
        NumPad1 = NumPad0 | A,
        NumPad2 = NumPad0 | B,
        NumPad3 = NumPad2 | NumPad1,
        NumPad4 = NumPad0 | D,
        NumPad5 = NumPad4 | NumPad1,
        NumPad6 = NumPad4 | NumPad2,
        NumPad7 = NumPad6 | NumPad5,
        NumPad8 = NumPad0 | H,
        NumPad9 = NumPad8 | NumPad1,
        Multiply = NumPad8 | NumPad2,
        Add = Multiply | NumPad9,
        Separator = NumPad8 | NumPad4,
        Subtract = Separator | NumPad9,
        Decimal = Separator | Multiply,
        Divide = Decimal | Subtract,
        F1 = NumPad0 | P,
        F2 = F1 | NumPad1,
        F3 = F1 | NumPad2,
        F4 = F3 | F2,
        F5 = F1 | NumPad4,
        F6 = F5 | F2,
        F7 = F5 | F3,
        F8 = F7 | F6,
        F9 = F1 | NumPad8,
        F10 = F9 | F2,
        F11 = F9 | F3,
        F12 = F11 | F10,
        F13 = F9 | F5,
        F14 = F13 | F10,
        F15 = F13 | F11,
        F16 = F15 | F14,
        F17 = 128,
        F18 = F17 | LButton,
        F19 = F17 | RButton,
        F20 = F19 | F18,
        F21 = F17 | MButton,
        F22 = F21 | F18,
        F23 = F21 | F19,
        F24 = F23 | F22,
        NumLock = F17 | ShiftKey,
        Scroll = NumLock | F18,
        LShiftKey = F17 | Space,
        RShiftKey = LShiftKey | F18,
        LControlKey = LShiftKey | F19,
        RControlKey = LControlKey | RShiftKey,
        LMenu = LShiftKey | F21,
        RMenu = LMenu | RShiftKey,
        BrowserBack = LMenu | LControlKey,
        BrowserForward = BrowserBack | RMenu,
        BrowserRefresh = LShiftKey | Down,
        BrowserStop = BrowserRefresh | RShiftKey,
        BrowserSearch = BrowserRefresh | LControlKey,
        BrowserFavorites = BrowserSearch | BrowserStop,
        BrowserHome = BrowserRefresh | LMenu,
        VolumeMute = BrowserHome | BrowserStop,
        VolumeDown = BrowserHome | BrowserSearch,
        VolumeUp = VolumeDown | VolumeMute,
        MediaNextTrack = LShiftKey | NumLock,
        MediaPreviousTrack = MediaNextTrack | RShiftKey,
        MediaStop = MediaNextTrack | LControlKey,
        MediaPlayPause = MediaStop | MediaPreviousTrack,
        LaunchMail = MediaNextTrack | LMenu,
        SelectMedia = LaunchMail | MediaPreviousTrack,
        LaunchApplication1 = LaunchMail | MediaStop,
        LaunchApplication2 = LaunchApplication1 | SelectMedia,
        Oem1 = MediaStop | BrowserSearch,
        OemSemicolon = Oem1,
        Oemplus = OemSemicolon | MediaPlayPause,
        Oemcomma = LaunchMail | BrowserHome,
        OemMinus = Oemcomma | SelectMedia,
        OemPeriod = Oemcomma | OemSemicolon,
        Oem2 = OemPeriod | OemMinus,
        OemQuestion = Oem2,
        Oem3 = 192,
        Oemtilde = Oem3,
        Oem4 = Oemtilde | Scroll | F20 | LWin,
        OemOpenBrackets = Oem4,
        Oem5 = Oemtilde | NumLock | F21 | RWin,
        OemPipe = Oem5,
        Oem6 = OemPipe | Scroll,
        OemCloseBrackets = Oem6,
        Oem7 = OemPipe | F23,
        OemQuotes = Oem7,
        Oem8 = OemQuotes | OemCloseBrackets,
        Oem102 = Oemtilde | LControlKey,
        OemBackslash = Oem102,
        ProcessKey = Oemtilde | RMenu,
        Packet = ProcessKey | OemBackslash,
        Attn = OemBackslash | LaunchApplication1,
        Crsel = Attn | Packet,
        Exsel = Oemtilde | MediaNextTrack | BrowserRefresh,
        EraseEof = Exsel | MediaPreviousTrack,
        Play = Exsel | OemBackslash,
        Zoom = Play | EraseEof,
        NoName = Exsel | OemPipe,
        Pa1 = NoName | EraseEof,
        OemClear = NoName | Play,
        KeyCode = 65535,
        Shift = 65536,
        Control = 131072,
        Alt = 262144,
    }

    /// <summary>
    /// <para>
    /// Used by <see cref="HotkeyRef.SendInput"/> to store information for synthesizing input events such as keystrokes, mouse movement, and mouse clicks.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-input"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INPUT
    {
        /// <summary>
        /// The type of the input event. This member can be one of the following values.
        /// <see cref="InputTypes.INPUT_MOUSE"/>, <see cref="InputTypes.INPUT_KEYBOARD"/>, <see cref="InputTypes.INPUT_HARDWARE"/>
        /// </summary>
        public InputTypes type;

#pragma warning disable IDE1006
        private UnionStruct DUMMYUNIONNAME;

        /// <summary></summary>
        public MOUSEINPUT mi
        {
            get => DUMMYUNIONNAME.mi;
            set => DUMMYUNIONNAME.mi = value;
        }

        /// <summary></summary>
        public KEYBDINPUT ki
        {
            get => DUMMYUNIONNAME.ki;
            set => DUMMYUNIONNAME.ki = value;
        }

        /// <summary></summary>
        public HARDWAREINPUT hi
        {
            get => DUMMYUNIONNAME.hi;
            set => DUMMYUNIONNAME.hi = value;
        }
#pragma warning restore IDE1006

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
        private struct UnionStruct
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;

            [FieldOffset(0)]
            public KEYBDINPUT ki;

            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }
    }
    public enum InputTypes : uint
    {
        /// <summary>
        /// The event is a mouse event. Use the <see cref="INPUT.mi"/> structure of the union.
        /// </summary>
        INPUT_MOUSE = 0,

        /// <summary>
        /// The event is a keyboard event. Use the <see cref="INPUT.ki"/> structure of the union.
        /// </summary>
        INPUT_KEYBOARD = 1,

        /// <summary>
        /// The event is a hardware event. Use the <see cref="INPUT.hi"/> structure of the union.
        /// </summary>
        INPUT_HARDWARE = 2,
    }
    /// <summary>
    /// <para>
    /// Contains information about a simulated mouse event.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-mouseinput"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// f the mouse has moved, indicated by <see cref="MOUSEEVENTF_MOVE"/>, <see cref="dx"/> and <see cref="dy"/> specify information about that movement.
    /// The information is specified as absolute or relative integer values.
    /// If <see cref="MOUSEEVENTF_ABSOLUTE"/> value is specified, <see cref="dx"/> and <see cref="dy"/> contain
    /// normalized absolute coordinates between 0 and 65,535.
    /// The event procedure maps these coordinates onto the display surface.
    /// Coordinate (0,0) maps onto the upper-left corner of the display surface; coordinate (65535,65535) maps onto the lower-right corner.
    /// In a multimonitor system, the coordinates map to the primary monitor.
    /// If <see cref="MOUSEEVENTF_VIRTUALDESK"/> is specified, the coordinates map to the entire virtual desktop.
    /// If the <see cref="MOUSEEVENTF_ABSOLUTE"/> value is not specified, <see cref="dx"/> and <see cref="dy"/> specify movement
    /// relative to the previous mouse event(the last reported position).
    /// Positive values mean the mouse moved right (or down); negative values mean the mouse moved left (or up).
    /// Relative mouse motion is subject to the effects of the mouse speed and the two-mouse threshold values.
    /// A user sets these three values with the Pointer Speed slider of the Control Panel's Mouse Properties sheet.
    /// You can obtain and set these values using the <see cref="SystemParametersInfo"/> function.
    /// The system applies two tests to the specified relative mouse movement.
    /// If the specified distance along either the x or y axis is greater than the first mouse threshold value,
    /// and the mouse speed is not zero, the system doubles the distance.
    /// If the specified distance along either the x or y axis is greater than the second mouse threshold value,
    /// and the mouse speed is equal to two, the system doubles the distance that resulted from applying the first threshold test.
    /// It is thus possible for the system to multiply specified relative mouse movement along the x or y axis by up to four times.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct MOUSEINPUT
    {
        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated,
        /// depending on the value of the <see cref="dwFlags"/> member.
        /// Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved.
        /// </summary>
        public int dx;

        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last mouse event was generated,
        /// depending on the value of the <see cref="dwFlags"/> member.
        /// Absolute data is specified as the y coordinate of the mouse; relative data is specified as the number of pixels moved.
        /// </summary>
        public int dy;

        /// <summary>
        /// If <see cref="dwFlags"/> contains <see cref="MOUSEEVENTF_WHEEL"/>, then <see cref="mouseData"/> specifies the amount of wheel movement.
        /// A positive value indicates that the wheel was rotated forward, away from the user;
        /// a negative value indicates that the wheel was rotated backward, toward the user.
        /// One wheel click is defined as <see cref="WHEEL_DELTA"/>, which is 120.
        /// Windows Vista:
        /// If <see cref="dwFlags"/> contains <see cref="MOUSEEVENTF_HWHEEL"/>, then <see cref="mouseData"/> specifies the amount of wheel movement.
        /// A positive value indicates that the wheel was rotated to the right; a negative value indicates that the wheel was rotated to the left.
        /// One wheel click is defined as <see cref="WHEEL_DELTA"/>, which is 120.
        /// If <see cref="dwFlags"/> does not contain <see cref="MOUSEEVENTF_WHEEL"/>, <see cref="MOUSEEVENTF_XDOWN"/>,
        /// or <see cref="MOUSEEVENTF_XUP"/>, then <see cref="mouseData"/> should be zero.
        /// If <see cref="dwFlags"/> contains <see cref="MOUSEEVENTF_XDOWN"/> or <see cref="MOUSEEVENTF_XUP"/>,
        /// then <see cref="mouseData"/> specifies which X buttons were pressed or released.
        /// This value may be any combination of the following flags.
        /// <see cref="XBUTTON1"/>, <see cref="XBUTTON2"/>
        /// </summary>
        public uint mouseData;

        /// <summary>
        /// A set of bit flags that specify various aspects of mouse motion and button clicks.
        /// The bits in this member can be any reasonable combination of the following values.
        /// The bit flags that specify mouse button status are set to indicate changes in status, not ongoing conditions.
        /// For example, if the left mouse button is pressed and held down, <see cref="MOUSEEVENTF_LEFTDOWN"/> is set
        /// when the left button is first pressed, but not for subsequent motions.
        /// Similarly, <see cref="MOUSEEVENTF_LEFTUP"/> is set only when the button is first released.
        /// You cannot specify both the <see cref="MOUSEEVENTF_WHEEL"/> flag and either <see cref="MOUSEEVENTF_XDOWN"/>
        /// or <see cref="MOUSEEVENTF_XUP"/> flags simultaneously in the <see cref="dwFlags"/> parameter,
        /// because they both require use of the <see cref="mouseData"/> field.
        /// <see cref="MOUSEEVENTF_ABSOLUTE"/>:
        /// The <see cref="dx"/> and <see cref="dy"/> members contain normalized absolute coordinates.
        /// If the flag is not set, <see cref="dx"/> and <see cref="dy"/> contain relative data (the change in position since the last reported position).
        /// This flag can be set, or not set, regardless of what kind of mouse or other pointing device, if any, is connected to the system.
        /// For further information about relative mouse motion, see the following Remarks section.
        /// <see cref="MOUSEEVENTF_HWHEEL"/>:
        /// The wheel was moved horizontally, if the mouse has a wheel.
        /// The amount of movement is specified in <see cref="mouseData"/>.
        /// Windows XP/2000:  This value is not supported.
        /// <see cref="MOUSEEVENTF_MOVE"/>:
        /// Movement occurred.
        /// <see cref="MOUSEEVENTF_MOVE_NOCOALESCE"/>:
        /// The <see cref="WM_MOUSEMOVE"/> messages will not be coalesced.
        /// The default behavior is to coalesce <see cref="WM_MOUSEMOVE"/> messages.
        /// Windows XP/2000:  This value is not supported.
        /// <see cref="MOUSEEVENTF_LEFTDOWN"/>:
        /// The left button was pressed.
        /// <see cref="MOUSEEVENTF_LEFTUP"/>:
        /// The left button was released.
        /// <see cref="MOUSEEVENTF_RIGHTDOWN"/>:
        /// The right button was pressed.
        /// <see cref="MOUSEEVENTF_RIGHTUP"/>:
        /// The right button was released.
        /// <see cref="MOUSEEVENTF_MIDDLEDOWN"/>:
        /// The middle button was pressed.
        /// <see cref="MOUSEEVENTF_MIDDLEUP"/>:
        /// The middle button was released.
        /// <see cref="MOUSEEVENTF_VIRTUALDESK"/>:
        /// Maps coordinates to the entire desktop. Must be used with <see cref="MOUSEEVENTF_ABSOLUTE"/>.
        /// <see cref="MOUSEEVENTF_WHEEL"/>:
        /// The wheel was moved, if the mouse has a wheel.
        /// The amount of movement is specified in <see cref="mouseData"/>.
        /// <see cref="MOUSEEVENTF_XDOWN"/>:
        /// An X button was pressed.
        /// <see cref="MOUSEEVENTF_XUP"/>:
        /// An X button was released.
        /// </summary>
        public MouseEventFlags dwFlags;

        /// <summary>
        /// The time stamp for the event, in milliseconds.
        /// If this parameter is 0, the system will provide its own time stamp.
        /// </summary>
        public ulong time;

        /// <summary>
        /// An additional value associated with the mouse event.
        /// An application calls <see cref="GetMessageExtraInfo"/> to obtain this extra information.
        /// </summary>
        public UIntPtr dwExtraInfo;
    }
    /// <summary>
    /// Mouse Event Flags
    /// </summary>
    public enum MouseEventFlags : uint
    {
        /// <summary>
        /// MOUSEEVENTF_MOVE
        /// </summary>
        MOUSEEVENTF_MOVE = 0x0001,

        /// <summary>
        /// MOUSEEVENTF_LEFTDOWN
        /// </summary>
        MOUSEEVENTF_LEFTDOWN = 0x0002,

        /// <summary>
        /// MOUSEEVENTF_LEFTUP
        /// </summary>
        MOUSEEVENTF_LEFTUP = 0x0004,

        /// <summary>
        /// MOUSEEVENTF_RIGHTDOWN
        /// </summary>
        MOUSEEVENTF_RIGHTDOWN = 0x0008,

        /// <summary>
        /// MOUSEEVENTF_RIGHTUP
        /// </summary>
        MOUSEEVENTF_RIGHTUP = 0x0010,

        /// <summary>
        /// MOUSEEVENTF_MIDDLEDOWN
        /// </summary>
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,

        /// <summary>
        /// MOUSEEVENTF_MIDDLEUP
        /// </summary>
        MOUSEEVENTF_MIDDLEUP = 0x0040,

        /// <summary>
        /// MOUSEEVENTF_XDOWN
        /// </summary>
        MOUSEEVENTF_XDOWN = 0x0080,

        /// <summary>
        /// MOUSEEVENTF_XUP
        /// </summary>
        MOUSEEVENTF_XUP = 0x0100,

        /// <summary>
        /// MOUSEEVENTF_WHEEL
        /// </summary>
        MOUSEEVENTF_WHEEL = 0x0800,

        /// <summary>
        /// MOUSEEVENTF_HWHEEL
        /// </summary>
        MOUSEEVENTF_HWHEEL = 0x01000,

        /// <summary>
        /// MOUSEEVENTF_MOVE_NOCOALESCE
        /// </summary>
        MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000,

        /// <summary>
        /// MOUSEEVENTF_VIRTUALDESK
        /// </summary>
        MOUSEEVENTF_VIRTUALDESK = 0x4000,

        /// <summary>
        /// MOUSEEVENTF_ABSOLUTE
        /// </summary>
        MOUSEEVENTF_ABSOLUTE = 0x8000,
    }
    /// <summary>
    /// <para>
    /// Contains information about a simulated keyboard event.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-keybdinput"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <see cref="INPUT_KEYBOARD"/> supports nonkeyboard-input methods—such as handwriting recognition or voice recognition—
    /// as if it were text input by using the <see cref="KEYEVENTF_UNICODE"/> flag.
    /// If <see cref="KEYEVENTF_UNICODE"/> is specified, <see cref="SendInput"/> sends a <see cref="WM_KEYDOWN"/> or <see cref="WM_KEYUP"/> message
    /// to the foreground thread's message queue with wParam equal to <see cref="VK_PACKET"/>.
    /// Once <see cref="GetMessage"/> or <see cref="PeekMessage"/> obtains this message, passing the message to <see cref="TranslateMessage"/>
    /// posts a <see cref="WM_CHAR"/> message with the Unicode character originally specified by <see cref="wScan"/>.
    /// This Unicode character will automatically be converted to the appropriate ANSI value if it is posted to an ANSI window.
    /// Set the <see cref="KEYEVENTF_SCANCODE"/> flag to define keyboard input in terms of the scan code.
    /// This is useful to simulate a physical keystroke regardless of which keyboard is currently being used.
    /// The virtual key value of a key may alter depending on the current keyboard layout or what other keys were pressed,
    /// but the scan code will always be the same.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct KEYBDINPUT
    {
        /// <summary>
        /// <para>
        /// Virtual Key Codes
        /// The following table shows the symbolic constant names, hexadecimal values, and mouse or keyboard equivalents
        /// for the virtual-key codes used by the system.
        /// The codes are listed in numeric order.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/inputdev/virtual-key-codes"/>
        /// </para>
        /// </summary>
        public ushort wVk;

        /// <summary>
        /// A hardware scan code for the key.
        /// If <see cref="dwFlags"/> specifies <see cref="KEYEVENTF_UNICODE"/>, <see cref="wScan"/> specifies a Unicode character
        /// which is to be sent to the foreground application.
        /// </summary>
        public ushort wScan;

        /// <summary>
        /// Specifies various aspects of a keystroke. This member can be certain combinations of the following values.
        /// <see cref="KEYEVENTF_EXTENDEDKEY"/>:
        /// If specified, the scan code was preceded by a prefix byte that has the value 0xE0 (224).
        /// <see cref="KEYEVENTF_KEYUP"/>:
        /// If specified, the key is being released.
        /// If not specified, the key is being pressed.
        /// <see cref="KEYEVENTF_SCANCODE"/>:
        /// If specified, <see cref="wScan"/> identifies the key and <see cref="wVk"/> is ignored.
        /// <see cref="KEYEVENTF_UNICODE"/>:
        /// If specified, the system synthesizes a <see cref="VK_PACKET"/> keystroke.
        /// The <see cref="wVk"/> parameter must be zero.
        /// This flag can only be combined with the <see cref="KEYEVENTF_KEYUP"/> flag.
        /// For more information, see the Remarks section.
        /// </summary>
        public uint dwFlags;

        /// <summary>
        /// The time stamp for the event, in milliseconds.
        /// If this parameter is zero, the system will provide its own time stamp.
        /// </summary>
        public uint time;

        /// <summary>
        /// An additional value associated with the keystroke.
        /// Use the <see cref="GetMessageExtraInfo"/> function to obtain this information.
        /// </summary>
        public UIntPtr dwExtraInfo;
    }
    /// <summary>
    /// <para>
    /// Contains information about a simulated message generated by an input device other than a keyboard or mouse.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/ns-winuser-hardwareinput"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct HARDWAREINPUT
    {
        /// <summary>
        /// <para>
        /// Windows Messages
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/winmsg/about-messages-and-message-queues"/>
        /// </para>
        /// </summary>
        public uint uMsg;

        /// <summary>
        /// The low-order word of the <see cref="MSG.lParam"/> parameter for <see cref="uMsg"/>.
        /// </summary>
        public ushort wParamL;

        /// <summary>
        /// The high-order word of the <see cref="MSG.lParam"/> parameter for <see cref="uMsg"/>.
        /// </summary>
        public ushort wParamH;
    }
}
