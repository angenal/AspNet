using System.Util.Win32.BaseTypes;
using System.Util.Win32.Enums;
using System.Util.Win32.Structs;
using static System.Util.Win32.Comctl32;
using static System.Util.Win32.Enums.INITCOMMONCONTROLSFlags;
using static System.Util.Win32.UnsafePInvokeExtensions;

namespace System.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// ListView
    /// </summary>
    public class ListView : BaseControl
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
        public ListView(string text, int x, int y, int width, int height, ListViewStyles style, HWND parentWindow) : base("SysListView32", text, x, y, width, height, (uint)style, parentWindow)
        {

        }

        /// <inheritdoc/>
        protected override bool Init() =>
            InitCommonControlsEx(new INITCOMMONCONTROLSEX
            {
                dwSize = SizeOf<INITCOMMONCONTROLSEX>(),
                dwICC = ICC_LISTVIEW_CLASSES,
            });
    }
}
