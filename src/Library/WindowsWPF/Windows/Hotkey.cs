using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Media;

namespace System.Windows
{
    /// <summary>WPF Hotkey Class. Must be instantiated in or after Window has been Loaded</summary>
    public class Hotkey : IDisposable
    {
        public event EventHandler<HotkeyEventArgs> HotkeyPressed;
        protected virtual void OnHotkeyPressed(HotkeyInfo info)
        {
            if (HotkeyPressed == null) return;
            HotkeyPressed(this, new HotkeyEventArgs(this, info));
        }
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
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="id">热键的ID值，用于跟踪管理此热键</param>
        /// <param name="fsModifiers">修饰键，Alt、Shift、Ctrl和Windows键</param>
        /// <param name="vk">某个字母键</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hwnd, int id, uint fsModifiers, uint vk);
        /// <summary>取消注册热键</summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <param name="id">注册热键时的ID值</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hwnd, int id);
        /// <summary>查找指定类名或标题的窗口句柄</summary>
        /// <param name="className">窗口类名，不指定则使用null值</param>
        /// <param name="windowText">窗口标题，不指定则使用null值</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string windowText);
        /// <summary>触发键盘事件</summary>
        /// <param name="bVk"></param>
        /// <param name="bScan"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwExtraInfo"></param>
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
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
}
