using System.Util.Win32.BaseTypes;
using System.Util.Win32.Enums;
using System.Util.Win32.Structs;
using static System.Util.Win32.Comctl32;
using static System.Util.Win32.UnsafePInvokeExtensions;
using static System.Util.Win32.Enums.INITCOMMONCONTROLSFlags;

namespace System.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// Trackbar
    /// </summary>
    public class Trackbar : BaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="style"></param>
        /// <param name="parentWindow"></param>
        public Trackbar(string text, int x, int y, int width, int height, TrackbarControlStyles style, HWND parentWindow) : base("msctls_trackbar32", text, x, y, width, height, (uint)style, parentWindow)
        {

        }

        /// <inheritdoc/>
        protected override bool Init() =>
            InitCommonControlsEx(new INITCOMMONCONTROLSEX
            {
                dwSize = SizeOf<INITCOMMONCONTROLSEX>(),
                dwICC = ICC_BAR_CLASSES,
            });

    }
}
