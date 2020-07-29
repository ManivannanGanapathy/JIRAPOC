using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JIRATest
{
    public partial class OpenIssueDashboard : System.Web.UI.Page
    {
        string sessionId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string baseUrl = ConfigurationManager.AppSettings["baseAPIUrl"];
            string loginApiUrl = ConfigurationManager.AppSettings["loginAPI"];
            string allOpenIssueUrl = ConfigurationManager.AppSettings["AllOpenIssueUrl"];

            JiraRequest jiraReq = new JiraRequest(baseUrl, loginApiUrl, allOpenIssueUrl, string.Empty, string.Empty);

            sessionId = Convert.ToString(Session["UserSessionId"]);
            jiraReq.GetJsonDataandWriteToFile(baseUrl, allOpenIssueUrl, sessionId);
        }
    }
}