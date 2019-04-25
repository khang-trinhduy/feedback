using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FeedbackUs.Models;

namespace FeedbackUs.Controllers
{
    public class RatingsController : Controller
    {
        private readonly FeedUSContext _context;

        public RatingsController(FeedUSContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Rate(int id)
        {
            var ratings = await _context.Rating.Include(r => r.Contents).ToListAsync();
            var rating = ratings.FirstOrDefault(r => r.Id == id);
            if (rating is null)
            {
                return NotFound();
            }
            return View("RateUs", rating);
        }

        public async Task<IActionResult> Contents()
        {
            var ratings = await _context.Rating.Include(r => r.Contents).ToListAsync();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in ratings)
            {
                list.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString() });
            }
            ViewBag.ratings = list;
            return View();
        }

        // GET: Ratings
        public async Task<IActionResult> Index()
        {
            var rating = await _context.Rating.Include(r => r.Contents).ToListAsync();
            return View(nameof(Index), rating);
        }

        public async Task<IActionResult> AddContent(int id, [FromBody]Content content)
        {
            var rating = await _context.Rating.FindAsync(id);
            if (rating is null)
            {
                return View("error");
            }
            rating.Contents.Add(content);
            _context.Update(rating);
            await _context.SaveChangesAsync();
            return Json(content);
        }

        [HttpPost]
        public async Task<IActionResult> Feedback([FromBody]FeedbackViewModel feedback)
        {
            if (feedback is null)
            {
                return View("error");
            }
            var newfeedback = new Feed { Contents = feedback.Contents, DateTime = DateTime.Now, Email = feedback.Email, RatingName = feedback.RatingName, Stars = feedback.Stars, UserName = feedback.UserName };
            var rating = await _context.Rating.FirstOrDefaultAsync(r => r.Name == feedback.RatingName);
            if (rating is null)
            {
                return View("error");
            }
            rating.Feedbacks.Add(newfeedback);
            _context.Update(rating);
            await _context.SaveChangesAsync();
            return Json("");
        }

        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ratings = await _context.Rating.Include(r => r.Contents).ToListAsync();
            var rating = ratings
                .FirstOrDefault(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ratings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]RatingView rate)
        {
            if (rate is null)
            {
                return View("Error");
            }
            var rating = new Rating(DateTime.Now, rate.Name, "");
            _context.Rating.Add(rating);
            await _context.SaveChangesAsync();
            return Json(rating);
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }
            return View(rating);
        }

        // POST: Ratings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,Rate,Feedback,Date")] Rating rating)
        {
            if (id != rating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RatingExists(rating.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(rating);
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rating = await _context.Rating
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rating == null)
            {
                return NotFound();
            }

            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rating = await _context.Rating.FindAsync(id);
            _context.Rating.Remove(rating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RatingExists(int id)
        {
            return _context.Rating.Any(e => e.Id == id);
        }
    }
}
