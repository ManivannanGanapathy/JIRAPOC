using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace JIRATest
{
    public class JiraRequest
    {

        //Properties
        private string loginResponse;
        private string jSessionId;
        private string jsonData;
        private string csvData;
        private bool writeToFileOutput;
        string baseUrl = string.Empty;
        string loginAPI = string.Empty;
        string allOpenIssueAPI = string.Empty;
        string loginUserName = string.Empty;
        string loginPwd = string.Empty;
        public bool errorsOccurred = false;
        //Constructor
        public JiraRequest(string newBaseUrl,string newLoginAPI,string allIssueAPI,string newUserName, string newLoginPwd)
        {
            this.baseUrl = newBaseUrl;
            this.loginAPI = newLoginAPI;
            this.loginUserName = newUserName;
            this.loginPwd = newLoginPwd;
            this.allOpenIssueAPI = allIssueAPI;
            loginResponse = "";
            jSessionId = "";
            jsonData = "";
            csvData = "";
            writeToFileOutput = false;            
        }

        //Methods
        public string LoginToJira()
        {
            try
            {
                WebRequest request = WebRequest.Create(this.baseUrl+this.loginAPI);
                String postData = "{\"username\":\"" + this.loginUserName + "\",\"password\":\"" + this.loginPwd + "\"}";

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                this.loginResponse = responseFromServer;
                //Console.WriteLine("\nloginResopnse:");
                //Console.WriteLine(this.loginResponse);

                return this.loginResponse;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in loginToJira: " + ex);
                this.errorsOccurred = true;

                return "Error Occured";
            }

        }

        public string ParseSessionID()
        {
            try
            {
                var dynObj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(this.loginResponse);
                this.jSessionId = dynObj["session"]["value"].Value;               
                return this.jSessionId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in parseJSessionID: " + ex);
                this.errorsOccurred = true;

                return "Error";
            }
        }

        public string GetJsonData()
        {
            try
            {
                String url = this.baseUrl + this.allOpenIssueAPI;
                //String url = this.baseURL + "api/2/user?username=alexA";
                //String url = this.baseURL + "api/2/issue/picker" + "?currentJQL=assignee%3Dadmin";

                WebRequest request = WebRequest.Create(url);
                request.Headers["Cookie"] = "JSESSIONID=" + this.jSessionId;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                this.jsonData = reader.ReadToEnd();
                WriteToFile(this.jsonData);
                reader.Close();
                dataStream.Close();
                response.Close();               

                return this.jsonData;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getJsonData: " + ex);
                this.errorsOccurred = true;
                return "Error Occured";
            }
        }

        public void FormatAsCSV()
        {

        }

        public void WriteToFile(string jsonData)
        {
            string path = HttpContext.Current.Server.MapPath("~/JsonData/");
            System.IO.File.WriteAllText(path + "AllJiraIssues.json", jsonData);
        }

        /// <summary>
        /// Method to Login into the JIRA Server.
        /// </summary>
        /// <param name="baseUrl">string</param>
        /// <param name="loginApi">string</param>
        /// <returns>string</returns>
        public string LoginToJiraServer(string baseUrl, string loginApi)
        {
            try
            {
                //setting the secutiry protocal to access the RESET API.
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //Creating a WebRequest
                WebRequest request = WebRequest.Create(baseUrl + loginApi);
                String postData = "{\"username\":\"" + this.loginUserName + "\",\"password\":\"" + this.loginPwd + "\"}";

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = byteArray.Length;

                
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                //Getting webResponse
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                String responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();

                //Get the Session object from the Response.                
                var dynObj = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(responseFromServer);
                this.jSessionId = dynObj["session"]["value"].Value;

                return this.jSessionId;
            }
            catch (Exception ex)
            {               
                this.errorsOccurred = true;

                return "Error Occurred";
            }

        }

        public void GetJsonDataandWriteToFile(string baseUrl, string allOpenIssueAPI, string sessionId)
        {
            try
            {
                String url = baseUrl + allOpenIssueAPI;
                //String url = this.baseURL + "api/2/user?username=alexA";
                //String url = this.baseURL + "api/2/issue/picker" + "?currentJQL=assignee%3Dadmin";

                WebRequest request = WebRequest.Create(url);
                request.Headers["Cookie"] = "JSESSIONID=" + sessionId;
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                this.jsonData = reader.ReadToEnd();
                WriteToFile(this.jsonData);
                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in getJsonData: " + ex);
                this.errorsOccurred = true;               
            }
        }
    }
}