﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JIRATest.Models
{
    public class Creator
    {
        public string name { get; set; }
        public string key { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }

    }
}