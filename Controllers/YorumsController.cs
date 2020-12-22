using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmSitesi.Models;

namespace FilmSitesi.Controllers
{
    public class YorumsController : Controller
    {
        private readonly VeriContext _context;

        public YorumsController(VeriContext context)
        {
            _context = context;
        }

        // GET: Yorums
        public async Task<IActionResult> Index()
        {
            return View(await _context.yorum.ToListAsync());
        }

        // GET: Yorums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.yorum
                .FirstOrDefaultAsync(m => m.id == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // GET: Yorums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yorums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,icerik")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yorum);
        }

        // GET: Yorums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.yorum.FindAsync(id);
            if (yorum == null)
            {
                return NotFound();
            }
            return View(yorum);
        }

        // POST: Yorums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,icerik")] Yorum yorum)
        {
            if (id != yorum.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumExists(yorum.id))
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
            return View(yorum);
        }

        // GET: Yorums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = await _context.yorum
                .FirstOrDefaultAsync(m => m.id == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // POST: Yorums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yorum = await _context.yorum.FindAsync(id);
            _context.yorum.Remove(yorum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YorumExists(int id)
        {
            return _context.yorum.Any(e => e.id == id);
        }
    }
}
