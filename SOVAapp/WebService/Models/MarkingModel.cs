﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class MarkingModel
    {
        public string MarkingUrl { get; set; }
        public string PostUrl { get; set; }
        public string MarkingAnnotation { get; set; }
        public DateTime MarkedDate { get; set; }

        public string AddAnnotation { get; set; }



    }
}