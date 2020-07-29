using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JIRATest.Login
{
    public partial class Login : System.Web.UI.Page
    {
        string loginUserName;
        string loginPassword;
        string loginResponse;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string baseUrl = ConfigurationManager.AppSettings["baseAPIUrl"];
            string loginApiUrl = ConfigurationManager.AppSettings["loginAPI"];
            string allOpenIssueUrl = ConfigurationManager.AppSettings["AllOpenIssueUrl"];
            loginUserName = txtUserName.Value;
            loginPassword = txtUserPwd.Value;
            JiraRequest jiraReq = new JiraRequest(baseUrl, loginApiUrl, allOpenIssueUrl, loginUserName, loginPassword);

    
            loginResponse = jiraReq.LoginToJiraServer(baseUrl, loginApiUrl);
            if (loginResponse != "Error Occurred")
            {
                Session["UserSessionId"] = loginResponse;
                Response.Redirect("~/OpenIssueDashboard.aspx");
            }
            else
            {
                LabelWarningErrorMessage.Text = loginResponse + "&nbsp;,&nbsp;Please try again";
            }
        }
    }
}