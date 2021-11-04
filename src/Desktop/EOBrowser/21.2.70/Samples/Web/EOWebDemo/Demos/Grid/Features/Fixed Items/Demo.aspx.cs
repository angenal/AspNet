using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using EO.Web.Demo;

public partial class Demos_Grid_Features_Fixed_Items_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Fill the Grid
        DataTable table = new DataTable();
        table.Columns.Add("ItemName", typeof(string));
        table.Columns.Add("ItemStyle", typeof(string));
        table.Columns.Add("Amount", typeof(string));
        table.Columns.Add("AmountStyle", typeof(string));
        table.Rows.Add(new object[] { "Inspiron Mino 9", "grid_bold_text", "$374.00", "grid_bold_text" });
        table.Rows.Add(new object[] { "Genuine Windows XP Home Edition", null, "included", null });
        table.Rows.Add(new object[] { "Accessories", null, "", null });
        table.Rows.Add(new object[] { "1GB DDR2 Memory", "indent1", "included", null });
        table.Rows.Add(new object[] { "8.9 inch LED display", "indent1", "included", null });
        table.Rows.Add(new object[] { "Intel 950 Graphics Card", "indent1", "included", null });
        table.Rows.Add(new object[] { "16G Solid State Drive", "indent1", "included", null });
        table.Rows.Add(new object[] { "Wireless 802.11g Mini Card", "indent1", "included", null });
        table.Rows.Add(new object[] { "Integrated 0.3M Pixel Webcam", "indent1", "included", null });
        table.Rows.Add(new object[] { "32Whr Battery", "indent1", "included", null });
        table.Rows.Add(new object[] { "Logitech V220 Cordless Mouse", "indent1", "$24.00", null });
        table.Rows.Add(new object[] { "Creative Labs EP-610 Headphones", "indent1", "$25.00", null });
        table.Rows.Add(new object[] { "Additional 4 Cell Battery", "indent1", "$100.00", null });
        table.Rows.Add(new object[] { "Discount", null, "-$50.00", "grid_red_text" });
        table.Rows.Add(new object[] { "Total", "grid_bold_text", "$473.00", "grid_bold_text" });

        Grid1.DataSource = table;
        Grid1.DataBind();
    }
}
