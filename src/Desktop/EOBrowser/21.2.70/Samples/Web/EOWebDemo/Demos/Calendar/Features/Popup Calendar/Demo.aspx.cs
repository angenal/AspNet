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

public partial class Demos_Calendar_Features_Popup_Calendar_Demo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            LoadData();
    }

    private void LoadData()
    {
        //Load data from the database
        using (DemoDB db = new DemoDB())
        {
            OleDbDataReader reader =
                db.ExecuteReader("select * from Tasks order by TaskID");
            DataGrid1.DataSource = reader;
            DataGrid1.DataBind();
        }

        //Replay changes and attach event handlers
        foreach (DataGridItem item in DataGrid1.Items)
        {
            Label lblTaskId = (Label)item.Cells[0].FindControl("taskId");

            //Attach client side event handlers
            HtmlAnchor startDateChangeLink =
                (HtmlAnchor)item.Cells[2].FindControl("startDateChangeLink");
            HtmlAnchor endDateChangeLink =
                (HtmlAnchor)item.Cells[3].FindControl("endDateChangeLink");
            startDateChangeLink.HRef =
                string.Format("javascript:ChangeDate('{0}', true);", lblTaskId.Text);
            endDateChangeLink.HRef =
                string.Format("javascript:ChangeDate('{0}', false);", lblTaskId.Text);

            //Search if we have any changes made on this item                
            ChangeEntry[] changes = GetChanges();
            if (changes != null)
            {
                for (int i = 0; i < changes.Length; i++)
                {
                    if (changes[i] == null)
                        continue;

                    if (lblTaskId.Text == changes[i].TaskID)
                    {
                        //Change found, apply the change
                        Label label = changes[i].BeginDate ?
                            (Label)item.Cells[2].FindControl("startDate") :
                            (Label)item.Cells[3].FindControl("endDate");

                        label.Text = changes[i].Date.ToString("d");
                    }
                }
            }
        }
    }

    //A log of changes are kept in the view state. Each
    //change is represented by a ChangeEntry object.
    //Which is a utility class to convert the change data
    //to and from a string. Saving string directly in the
    //view state is more efficient than saving complex 
    //objects there
    private class ChangeEntry
    {
        //The ID of the task to be changed
        private string m_szTaskId;

        //Whether the change is for begin date or end date
        private bool m_bBeginDate;

        //The new date
        private DateTime m_Date;

        public ChangeEntry(string data)
        {
            string[] parts = data.Split(',');
            m_szTaskId = parts[0];
            m_bBeginDate = parts[1] == "Y";
            m_Date = EO.Web.Calendar.StringToDate(parts[2]);
        }

        public ChangeEntry(string szTaskId, bool bBeginDate, DateTime date)
        {
            m_szTaskId = szTaskId;
            m_bBeginDate = bBeginDate;
            m_Date = date;
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}",
                m_szTaskId,
                m_bBeginDate ? "Y" : string.Empty,
                EO.Web.Calendar.DateToString(m_Date));
        }

        public string TaskID
        {
            get
            {
                return m_szTaskId;
            }
        }

        public bool BeginDate
        {
            get
            {
                return m_bBeginDate;
            }
        }

        public DateTime Date
        {
            get
            {
                return m_Date;
            }
        }
    }

    private void LogChange(string changeData)
    {
        //Get the number of changes
        object oChangeCount = ViewState["change.count"];
        int nChangeCount = oChangeCount != null ? (int)oChangeCount : 0;

        //Store the new one
        ViewState["change." + nChangeCount.ToString()] = changeData;
        nChangeCount++;
        ViewState["change.count"] = nChangeCount;
    }

    private ChangeEntry[] GetChanges()
    {
        //Get the number of changes
        object oChangeCount = ViewState["change.count"];
        int nChangeCount = oChangeCount != null ? (int)oChangeCount : 0;

        // Return a null reference for empty change entries.
        if (nChangeCount == 0)
            return null;

        //Read values
        ChangeEntry[] entries = new ChangeEntry[nChangeCount];
        for (int i = 0; i < nChangeCount; i++)
        {
            string changeData = (string)ViewState["change." + i.ToString()];
            entries[i] = new ChangeEntry(changeData);
        }

        return entries;
    }

    protected void CallbackPanel1_Execute(object sender, EO.Web.CallbackEventArgs e)
    {
        LogChange(e.Parameter);
        LoadData();
    }
}
