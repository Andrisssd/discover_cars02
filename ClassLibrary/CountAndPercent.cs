using System;

namespace ClassLibrary
{
    public class CountAndPercent
    {
        public int Count { get; set; }
        public double? Percent { get; set; }
        public int? Place { get; set; }

        public CountAndPercent()
        {
            Count = 1;
        }
    }
}
