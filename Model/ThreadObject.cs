﻿using System.Collections.Generic;
using LedGeekBox.Model.Scenario;

namespace LedGeekBox.Model
{
    public class ThreadObject
    {
        public string WhatToWrite1 { get; set; }
        public string WhatToWrite2 { get; set; }
        
        public List<IStep> Steps { get; set; }
        //public bool FirstLine { get; set; }
        public bool Reverse { get; set; }
    }
}