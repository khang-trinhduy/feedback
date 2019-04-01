using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackUs.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string RatingName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Contents { get; set; }
        public DateTime DateTime { get; set; }
        public int Stars { get; set; }
    }
}
