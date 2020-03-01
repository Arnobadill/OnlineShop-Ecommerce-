using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class TagNamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TagNamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TagNames
        public async Task<IActionResult> Index()
        {
            return View(await _context.tagNames.ToListAsync());
        }

        // GET: TagNames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagName = await _context.tagNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tagName == null)
            {
                return NotFound();
            }

            return View(tagName);
        }

        // GET: TagNames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TagNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TagNames")] TagName tagName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tagName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tagName);
        }

        // GET: TagNames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagName = await _context.tagNames.FindAsync(id);
            if (tagName == null)
            {
                return NotFound();
            }
            return View(tagName);
        }

        // POST: TagNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TagNames")] TagName tagName)
        {
            if (id != tagName.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tagName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagNameExists(tagName.Id))
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
            return View(tagName);
        }

        // GET: TagNames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tagName = await _context.tagNames
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tagName == null)
            {
                return NotFound();
            }

            return View(tagName);
        }

        // POST: TagNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tagName = await _context.tagNames.FindAsync(id);
            _context.tagNames.Remove(tagName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TagNameExists(int id)
        {
            return _context.tagNames.Any(e => e.Id == id);
        }
    }
}
