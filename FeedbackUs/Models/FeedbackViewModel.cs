using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackUs.Models
{
    public class FeedbackViewModel
    {
        public string RatingName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Contents { get; set; }
        public int Stars { get; set; }
    }
}
