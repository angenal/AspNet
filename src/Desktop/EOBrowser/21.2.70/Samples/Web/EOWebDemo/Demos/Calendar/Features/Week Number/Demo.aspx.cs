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
using EO.Web;

public partial class Demos_Calendar_Features_Week_Number_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void WeekNumberBase_CheckedChanged(object sender, System.EventArgs e)
    {
        if (WeekNumberMonth.Checked)
        {
            Calendar1.WeekNumberBase = CalendarWeekNumberBase.Month;
            DatePicker1.WeekNumberBase = CalendarWeekNumberBase.Month;
        }
        else
        {
            Calendar1.WeekNumberBase = CalendarWeekNumberBase.Year;
            DatePicker1.WeekNumberBase = CalendarWeekNumberBase.Year;
        }
    }
}
