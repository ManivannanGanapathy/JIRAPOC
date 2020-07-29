using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JIRATest.Models
{
    public class Root
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Issue> issues { get; set; }

    }
}