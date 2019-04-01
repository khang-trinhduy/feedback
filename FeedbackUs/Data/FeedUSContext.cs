using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FeedbackUs.Models;

namespace FeedbackUs.Models
{
    public class FeedUSContext : DbContext
    {
        public FeedUSContext (DbContextOptions<FeedUSContext> options)
            : base(options)
        {
        }

        public DbSet<FeedbackUs.Models.Rating> Rating { get; set; }

        public DbSet<FeedbackUs.Models.Content> Content { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

    }
}
