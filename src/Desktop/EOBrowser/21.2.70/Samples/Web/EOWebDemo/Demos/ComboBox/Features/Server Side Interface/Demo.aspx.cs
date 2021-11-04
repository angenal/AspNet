using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Demos_ComboBox_Features_Server_Side_Interface_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ComboBox1_TextChanged(object sender, EventArgs e)
    {
        lblResult.Text = string.Format(
            "Selected Item Index: {0}, ComboBox Text: {1}",
            ListBox1.SelectedIndex, ComboBox1.Text);
    }
}
