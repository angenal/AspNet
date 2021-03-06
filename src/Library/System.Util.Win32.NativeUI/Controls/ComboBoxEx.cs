using System.Util.Win32.BaseTypes;
using System.Util.Win32.Enums;
using System.Util.Win32.Structs;
using static System.Util.Win32.Comctl32;
using static System.Util.Win32.UnsafePInvokeExtensions;
using static System.Util.Win32.Enums.INITCOMMONCONTROLSFlags;

namespace System.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// ComboBoxEx
    /// </summary>
    public class ComboBoxEx : BaseControl
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
        /// <param name="exStyles"></param>
        /// <param name="parentWindow"></param>
        public ComboBoxEx(string text, int x, int y, int width, int height, ComboBoxStyles style, ComboBoxExStyles exStyles, HWND parentWindow) : base("ComboBoxEx32", text, x, y, width, height, (uint)style, (uint)exStyles, parentWindow)
        {

        }

        /// <inheritdoc/>
        protected override bool Init() =>
            InitCommonControlsEx(new INITCOMMONCONTROLSEX
            {
                dwSize = SizeOf<INITCOMMONCONTROLSEX>(),
                dwICC = ICC_USEREX_CLASSES,
            });
    }
}
