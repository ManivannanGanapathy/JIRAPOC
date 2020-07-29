using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JIRATest
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            String baseUrl = "https://jira.castsoftware.com/rest/";

                ////"https://jira.castsoftware.com/rest/";
            string loginAPI = "auth/1/session";

            String allOpenIssuesAPI = "api/2/search?jql=project=%22University%22";
            string loginUserName = "MGN";
            string loginPassword = "June@123";
            //string alternativeUrl="https://jira.castsoftware.com/browse/";
            Response.Write("Process Started");           
            JiraRequest jiraReq = new JiraRequest(baseUrl, loginAPI, allOpenIssuesAPI, loginUserName, loginPassword);

            //dev-status/1.0/issue/summary?issueId=293943&_=1594131758546

            if (!jiraReq.errorsOccurred)
            {
                Response.Write(jiraReq.LoginToJira());
            }

            if (!jiraReq.errorsOccurred)
            {
                Response.Write(jiraReq.ParseSessionID());
            }

            if (!jiraReq.errorsOccurred)
            {
                Response.Write(jiraReq.GetJsonData());
            }

            //if (!errorsOccurred)
            //{
            //    FormatAsCSV();
            //}
            //if (!errorsOccurred)
            //{
            //    WriteToFile();
            //}

            Response.Write("Process Finished");
        }
    }
}