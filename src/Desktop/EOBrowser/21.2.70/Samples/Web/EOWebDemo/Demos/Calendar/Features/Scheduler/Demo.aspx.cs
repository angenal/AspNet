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
using System.Data.OleDb;
using EO.Web.Demo;

public partial class Demos_Calendar_Features_Scheduler_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadHolidays();
    }

    //Structure to hold holiday information
    private class Holiday
    {
        public string Name;
        public DateTime Date;
        public string Icon;
    }

    private Hashtable m_htHolidays;

    private void LoadHolidays()
    {
        m_htHolidays = new Hashtable();

        using (DemoDB db = new DemoDB())
        {
            using (OleDbDataReader reader =
                       db.ExecuteReader("select * from Holidays order by HolidayDate"))
            {
                while (reader.Read())
                {
                    Holiday day = new Holiday();
                    day.Name = reader["HolidayName"].ToString();
                    day.Date = (DateTime)reader["HolidayDate"];
                    day.Icon = reader["HolidayIcon"].ToString();
                    m_htHolidays[day.Date] = day;
                }
            }
        }
    }

    protected void Calendar1_DayRender(object sender, EO.Web.DayRenderEventArgs e)
    {
        //Check if there is a matching holiday
        Holiday holiday = (Holiday)m_htHolidays[e.Day.Date];

        if (holiday == null)
            e.Writer.Write(e.Day.DayNumberText);
        else
        {
            //Otherwise output the holiday information. We use
            //a table here to arrange the layout
            e.Writer.Write("<table border=\"0\" cellSpacing=\"0\" cellPadding=\"0\">");
            e.Writer.Write("<tr>");

            //Write the icon
            e.Writer.Write("<td align=\"left\">");
            if (holiday.Icon != string.Empty)
                e.Writer.Write("<img src=\"{0}\" />", this.ResolveUrl(holiday.Icon));
            e.Writer.Write("</td>");

            //Write the day text
            e.Writer.Write("<td align=\"right\">");
            e.Writer.Write(e.Day.DayNumberText);
            e.Writer.Write("</td>");

            e.Writer.Write("</tr><tr>");

            //Write the holiday name
            e.Writer.Write("<td colspan=\"2\" align=\"left\"><div style=\"width:70px;height:28px;overflow:hidden;line-height:14px;\">");
            e.Writer.Write(holiday.Name);
            e.Writer.Write("</div></td>");

            e.Writer.Write("</tr></table>");
        }
    }
}
