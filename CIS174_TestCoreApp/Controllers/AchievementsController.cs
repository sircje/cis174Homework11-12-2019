using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIS174_TestCoreApp;
using CIS174_TestCoreApp.Models;

namespace CIS174_TestCoreApp.Controllers
{
    public class AchievementsController : Controller
    {
        private readonly AppDbContext _context;

        public AchievementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Achievements
        public async Task<IActionResult> Index()
        {
            return View(await _context.Achievements.ToListAsync());
        }

        // GET: Achievements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achievements = await _context.Achievements
                .FirstOrDefaultAsync(m => m.AchievementsId == id);
            if (achievements == null)
            {
                return NotFound();
            }

            return View(achievements);
        }

        // GET: Achievements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Achievements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AchievementsId,FamousPeopleId,name,doa")] Achievements achievements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(achievements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(achievements);
        }

        // GET: Achievements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achievements = await _context.Achievements.FindAsync(id);
            if (achievements == null)
            {
                return NotFound();
            }
            return View(achievements);
        }

        // POST: Achievements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AchievementsId,FamousPeopleId,name,doa")] Achievements achievements)
        {
            if (id != achievements.AchievementsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achievements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchievementsExists(achievements.AchievementsId))
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
            return View(achievements);
        }

        // GET: Achievements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var achievements = await _context.Achievements
                .FirstOrDefaultAsync(m => m.AchievementsId == id);
            if (achievements == null)
            {
                return NotFound();
            }

            return View(achievements);
        }

        // POST: Achievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var achievements = await _context.Achievements.FindAsync(id);
            _context.Achievements.Remove(achievements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchievementsExists(int id)
        {
            return _context.Achievements.Any(e => e.AchievementsId == id);
        }
    }
}
