using LedGeekBox.Model.Scenario;

namespace LedGeekBox.Model
{
    public class ThreadObject
    {
        public string WhatToWrite { get; set; }
        public IStep ViewModel { get; set; }
        public bool FirstLine { get; set; }
        public bool Reverse { get; set; }
    }
}