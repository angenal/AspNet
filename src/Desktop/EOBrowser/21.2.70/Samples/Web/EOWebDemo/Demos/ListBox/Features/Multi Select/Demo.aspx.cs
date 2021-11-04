using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_ListBox_Features_Multi_Select_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region SAMPLE_BLOCK#1
    protected void cbModifier_TextChanged(object sender, EventArgs e)
    {
        switch (lbModifier.SelectedIndex)
        {
            case 0:
                ListBox1.MultiSelectModifier = EO.Web.ModifierKeys.Shift;
                break;
            case 1:
                ListBox1.MultiSelectModifier = EO.Web.ModifierKeys.Control;
                break;
            default:
                ListBox1.MultiSelectModifier = EO.Web.ModifierKeys.Alt;
                break;
        }
    }
    #endregion
}
