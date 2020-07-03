﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FeeCalculator.Model
{
    public class Special
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double TotalPrice { get; set; }
        public Duration Entry { get; set; }
        public Duration Exit { get; set; }
        public int MaxDays { get; set; }
    }
}
