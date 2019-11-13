//Assignment 11.1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIS174_TestCoreApp;
using CIS174_TestCoreApp.Models;
using CIS174_TestCoreApp.Filters;

namespace CIS174_TestCoreApp.Controllers
{
    [LogResourceFilter]
    public class FamousPeoplesController : Controller
    {
        private readonly AppDbContext _context;

        public FamousPeoplesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FamousPeoples
        [Route("Assignment10_1")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.FamousPeoples.ToListAsync());
        }

        // GET: FamousPeoples/Details/5
        [Route("Assignment10_1/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var famousPeople = await _context.FamousPeoples
                .FirstOrDefaultAsync(m => m.FamousPeopleId == id);
            if (famousPeople == null)
            {
                return NotFound();
            }

            return View(famousPeople);
        }

        
        public IActionResult List()
        {
            return View();
        }
        // GET: FamousPeoples/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FamousPeople famousPeople)
        {
            if (ModelState.IsValid)
            {
                Services.FamousPeopleService.CreateFamousPeople(famousPeople);
                _context.Add(famousPeople);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(famousPeople);
        }

        // GET: FamousPeoples/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var famousPeople = await _context.FamousPeoples.FindAsync(id);
            if (famousPeople == null)
            {
                return NotFound();
            }
            return View(famousPeople);
        }

        // POST: FamousPeoples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("firstName,FamousPeopleId,lastName,birthDate,city,state")] FamousPeople famousPeople)
        {
            if (id != famousPeople.FamousPeopleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(famousPeople);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamousPeopleExists(famousPeople.FamousPeopleId))
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
            return View(famousPeople);
        }

        // GET: FamousPeoples/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var famousPeople = await _context.FamousPeoples
                .FirstOrDefaultAsync(m => m.FamousPeopleId == id);
            if (famousPeople == null)
            {
                return NotFound();
            }

            return View(famousPeople);
        }

        // POST: FamousPeoples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var famousPeople = await _context.FamousPeoples.FindAsync(id);
            _context.FamousPeoples.Remove(famousPeople);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamousPeopleExists(int id)
        {
            return _context.FamousPeoples.Any(e => e.FamousPeopleId == id);
        }
    }
}
