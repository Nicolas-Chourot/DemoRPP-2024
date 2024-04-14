﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRPP.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PublishedTime { get; set; } = DateTime.Now;
    }
}