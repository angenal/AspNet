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

public partial class Demos_Grid_Features_Conditional_Formatting___Cell_Based_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Grid1.DataSource = CreateTestTable();
        Grid1.DataBind();
    }

    private DataTable CreateTestTable()
    {
        // Create a test DataTable with an account number
        // and an account balance row
        DataTable table;
        DataColumn column;
        table = new DataTable("Accounts");
        column = new DataColumn("AccountNo", typeof(string));
        table.Columns.Add(column);
        column = new DataColumn("Balance", typeof(decimal));
        table.Columns.Add(column);
        column = new DataColumn("BalanceStyle", typeof(string));
        table.Columns.Add(column);

        // Add 100 rows
        DataRow row;
        Random random = new Random();
        for (int i = 0; i < 100; i++)
        {
            row = table.NewRow();

            //Create a fake account number
            row["AccountNo"] = string.Format("10000{0:00}", i);

            //Create a random balance between -50 and 50
            decimal balance = random.Next(100) - 50;
            row["Balance"] = balance;

            //Set "BalanceStyle" to "negative_balance" if
            //the balance is blow zero. Since the "Balance"
            //column's StyleField is set to "BalanceStyle",
            //value set here will be populated into the
            //cell's Style property and to be applied at
            //runtime
            if (balance < 0)
                row["BalanceStyle"] = "negative_balance";
            table.Rows.Add(row);
        }

        return table;
    }
}
