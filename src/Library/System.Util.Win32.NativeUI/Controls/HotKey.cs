using System.Util.Win32.BaseTypes;
using System.Util.Win32.Structs;
using static System.Util.Win32.Comctl32;
using static System.Util.Win32.Enums.INITCOMMONCONTROLSFlags;
using static System.Util.Win32.UnsafePInvokeExtensions;

namespace System.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// HotKey
    /// </summary>
    public class HotKey : BaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="parentWindow"></param>
        public HotKey(string text, int x, int y, int width, int height, HWND parentWindow) : base("msctls_hotkey32", text, x, y, width, height, 0, parentWindow)
        {

        }

        /// <inheritdoc/>
        protected override bool Init() =>
            InitCommonControlsEx(new INITCOMMONCONTROLSEX
            {
                dwSize = SizeOf<INITCOMMONCONTROLSEX>(),
                dwICC = ICC_HOTKEY_CLASS,
            });
    }
}
