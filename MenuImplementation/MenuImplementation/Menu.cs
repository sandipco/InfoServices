﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuImplementation
{
    public class Menu
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public int? ParentId { get; set; }
    }
}
