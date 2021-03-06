using System.Util.Win32.BaseTypes;
using System.Util.Win32.Enums;
using System.Util.Win32.Structs;
using static System.Util.Win32.Comctl32;
using static System.Util.Win32.Enums.INITCOMMONCONTROLSFlags;
using static System.Util.Win32.UnsafePInvokeExtensions;

namespace System.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// SysLink
    /// </summary>
    public class SysLink : BaseControl
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
        public SysLink(string text, int x, int y, int width, int height, SysLinkStyles style, HWND parentWindow) : base("SysLink", text, x, y, width, height, (uint)style, parentWindow)
        {

        }

        /// <inheritdoc/>
        protected override bool Init() =>
            InitCommonControlsEx(new INITCOMMONCONTROLSEX
            {
                dwSize = SizeOf<INITCOMMONCONTROLSEX>(),
                dwICC = ICC_LINK_CLASS,
            });

    }
}
