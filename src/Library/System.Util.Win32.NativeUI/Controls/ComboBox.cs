using System.Util.Win32.BaseTypes;
using System.Util.Win32.Enums;

namespace System.Util.Win32.NativeUI.Controls
{
    /// <summary>
    /// ComboBox
    /// </summary>
    public class ComboBox : BaseControl
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
        public ComboBox(string text, int x, int y, int width, int height, ComboBoxStyles style, HWND parentWindow) : base("ComboBox", text, x, y, width, height, (uint)style, parentWindow)
        {

        }
    }
}
