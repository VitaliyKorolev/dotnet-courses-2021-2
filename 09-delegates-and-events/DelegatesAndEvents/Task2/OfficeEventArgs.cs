using System;

namespace Task2
{
    partial class Program
    {
        public class OfficeEventArgs : EventArgs
        {
            public string Name { get; set; }
            public DateTime Time { get; set; }
        }
    }
}
