using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcFeeder.Models;

namespace MvcFeeder.Controllers
{
    public class BreastFeedsController : Controller
    {
        private readonly MvcFeederContext _context;

        public BreastFeedsController(MvcFeederContext context)
        {
            _context = context;
        }



        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


        // GET: BreastFeeds
        public async Task<IActionResult> Index(string FeedingSide, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from f in _context.BreastFeed
                                            orderby f.Side
                                            select f.Side;

            var BreastFeeds = from f in _context.BreastFeed
                         select f;

            if (!string.IsNullOrEmpty(searchString))
            {
                BreastFeeds = BreastFeeds.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(FeedingSide))
            {
                BreastFeeds = BreastFeeds.Where(x => x.Side == FeedingSide);
            }

            var FeedingSideVM = new FeedingSideViewModel
            {
                Sides = new SelectList(await genreQuery.Distinct().ToListAsync()),
                BreastFeeds = await BreastFeeds.ToListAsync()
            };

            return View(FeedingSideVM);
        }
        // GET: BreastFeeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breastFeed = await _context.BreastFeed
                .SingleOrDefaultAsync(m => m.Id == id);
            if (breastFeed == null)
            {
                return NotFound();
            }

            return View(breastFeed);
        }

        // GET: BreastFeeds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BreastFeeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Side,hour,Note")] BreastFeed breastFeed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breastFeed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breastFeed);
        }

        // GET: BreastFeeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breastFeed = await _context.BreastFeed.SingleOrDefaultAsync(m => m.Id == id);
            if (breastFeed == null)
            {
                return NotFound();
            }
            return View(breastFeed);
        }

        // POST: BreastFeeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Side,hour,Note")] BreastFeed breastFeed)
        {
            if (id != breastFeed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breastFeed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreastFeedExists(breastFeed.Id))
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
            return View(breastFeed);
        }

        // GET: BreastFeeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breastFeed = await _context.BreastFeed
                .SingleOrDefaultAsync(m => m.Id == id);
            if (breastFeed == null)
            {
                return NotFound();
            }

            return View(breastFeed);
        }

        // POST: BreastFeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breastFeed = await _context.BreastFeed.SingleOrDefaultAsync(m => m.Id == id);
            _context.BreastFeed.Remove(breastFeed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreastFeedExists(int id)
        {
            return _context.BreastFeed.Any(e => e.Id == id);
        }
    }
}
