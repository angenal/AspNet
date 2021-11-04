using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class WebAuth : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /////////////////////////////////////////////////////
        // The following code is for demonstration purpose
        // only. In real life applications, you would almost
        // NEVER need to write code to handle HTTP 
        // Authorization header because authorization is
        // usually configured through IIS Manager directly,
        // or implemented through a login form
        /////////////////////////////////////////////////////

        string authHeader = Request.Headers["Authorization"];
        if ((authHeader == null) ||
            !authHeader.StartsWith("Basic"))
        {
            OnAuthError();
        }

        authHeader = authHeader.Substring(6).Trim();
        authHeader = Encoding.ASCII.GetString(Convert.FromBase64String(authHeader));
        string[] parts = authHeader.Split(':');
        if ((parts.Length < 2) ||
            (parts[0].Trim() != "eopdf") ||
            (parts[1].Trim() != "eopdf"))
        {
            OnAuthError();
        }
    }

    private void OnAuthError()
    {
        Response.Clear();
        Response.StatusCode = 401;
        Response.AppendHeader("WWW-Authenticate", "Basic realm=\"Demo\"");
        Response.End();
    }
}
