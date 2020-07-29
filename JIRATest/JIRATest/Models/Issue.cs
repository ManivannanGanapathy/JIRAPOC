using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JIRATest.Models
{
    public class Issue
    {
        public string id { get; set; }
        public string key { get; set; }
        public Assignee assignee { get; set; }
        public Reporter reporter { get; set; }
        public Issuetype issuetype { get; set; }
        public Project project { get; set; }
        public DateTime updated { get; set; }
        public string description { get; set; }
        public string summary { get; set; }
        public Priority priority { get; set; }
        public Status status { get; set; }
        public Customfield22784 customfield_22784 { get; set; }
        public Creator creator { get; set; }
        public DateTime created { get; set; }

    }
}