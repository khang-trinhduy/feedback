using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FeedbackUs.Models
{
    public class Rating
    {
        public Rating(DateTime date, string name, string url)
        {
            Contents = new List<Content>();
            Feedbacks = new List<Feed>();
            Date = date;
            Name = name;
            RDURL = url;
        }

        public Rating() {
            Feedbacks = new List<Feed>();
            Contents = new List<Content>();
        }

        public int Id { get; set; }
        //public string UserName { get; set; }
        //public string Email { get; set; }
        //public Rate Rate { get; set; }
        //[Required]
        //public string Feedback { get; set; }
        public List<Content> Contents { get; set; }
        public List<Feed> Feedbacks { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string RDURL { get; set; }
    }

}
