﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeSC.Data
{
    public class TakenOutModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Quantity { get; set; }   
        public string TakenBy { get; set; } 

        public string ApprovedBy { get; set; }
        public DateTime Date { get; set; }  

    }
}
