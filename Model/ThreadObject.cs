using System.Collections.Generic;
using LedGeekBox.Model.Scenario;

namespace LedGeekBox.Model
{
    public class ThreadObject
    {
        public string WhatToWrite { get; set; }
        public List<IStep> Steps { get; set; }
        public bool FirstLine { get; set; }
        public bool Reverse { get; set; }
    }
}