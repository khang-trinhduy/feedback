using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackUs.Models
{
    public class Content
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string Feedback { get; set; }
        public bool IsNotNegative { get; set; }
    }
}
