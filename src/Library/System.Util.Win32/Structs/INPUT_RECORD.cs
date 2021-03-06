using System.Util.Win32.Enums;
using System.Util.Win32.Marshals;
using System.Runtime.InteropServices;
using static System.Util.Win32.Enums.InputRecordEventTypes;
using static System.Util.Win32.Kernel32;

namespace System.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Describes an input event in the console input buffer.
    /// These records can be read from the input buffer by using the <see cref="ReadConsoleInput"/> or <see cref="PeekConsoleInput"/> function,
    /// or written to the input buffer by using the <see cref="WriteConsoleInput"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/console/input-record-str"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct INPUT_RECORD
    {
        /// <summary>
        /// A handle to the type of input event and the event record stored in the <see cref="Event"/> member.
        /// This member can be one of the following values.
        /// <see cref="FOCUS_EVENT"/>,<see cref="KEY_EVENT"/>, <see cref="MENU_EVENT"/>, <see cref="MOUSE_EVENT"/>, <see cref="WINDOW_BUFFER_SIZE_EVENT"/>
        /// </summary>
        public InputRecordEventTypes EventType;

        /// <summary>
        /// The event information.
        /// The format of this member depends on the event type specified by the <see cref="EventType"/> member.
        /// </summary>
        public UnionStruct Event;

        /// <summary>
        /// 
        /// </summary>
        public KEY_EVENT_RECORD KeyEvent
        {
            get => Event.KeyEvent;
            set => Event.KeyEvent = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public MOUSE_EVENT_RECORD MouseEvent
        {
            get => Event.MouseEvent;
            set => Event.MouseEvent = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent
        {
            get => Event.WindowBufferSizeEvent;
            set => Event.WindowBufferSizeEvent = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public MENU_EVENT_RECORD MenuEvent
        {
            get => Event.MenuEvent;
            set => Event.MenuEvent = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public FOCUS_EVENT_RECORD FocusEvent
        {
            get => Event.FocusEvent;
            set => Event.FocusEvent = value;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
        public struct UnionStruct
        {
            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public KEY_EVENT_RECORD KeyEvent;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public MOUSE_EVENT_RECORD MouseEvent;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public WINDOW_BUFFER_SIZE_RECORD WindowBufferSizeEvent;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public MENU_EVENT_RECORD MenuEvent;

            /// <summary>
            /// 
            /// </summary>
            [FieldOffset(0)]
            public FOCUS_EVENT_RECORD FocusEvent;
        }
    }
}
