using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JIRATest.Models
{
    public class Project
    {
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string projectTypeKey { get; set; }
        public ProjectCategory projectCategory { get; set; }

    }
}