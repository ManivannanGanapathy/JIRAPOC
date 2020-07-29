using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JIRATest.Models
{
    public class Status
    {
        public string description { get; set; }
        public string name { get; set; }
        public StatusCategory statusCategory { get; set; }

    }
}