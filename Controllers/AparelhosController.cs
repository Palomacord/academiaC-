using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using  Academia.Models;


namespace Academia.Controllers
{
    public class AparelhosController : Controller
    {
        private readonly AcademiaContext _context;

        public AparelhosController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: Aparelhos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aparelhos.ToListAsync());
        }

        // GET: Aparelhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparelho = await _context.Aparelhos
                .FirstOrDefaultAsync(m => m.AparelhosId == id);
            if (aparelho == null)
            {
                return NotFound();
            }

            return View(aparelho);
        }

        // GET: Aparelhos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aparelhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AparelhosId,Nome,Link")] Aparelho aparelho)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aparelho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aparelho);
        }

        // GET: Aparelhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparelho = await _context.Aparelhos.FindAsync(id);
            if (aparelho == null)
            {
                return NotFound();
            }
            return View(aparelho);
        }

        // POST: Aparelhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AparelhosId,Nome,Link")] Aparelho aparelho)
        {
            if (id != aparelho.AparelhosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aparelho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AparelhoExists(aparelho.AparelhosId))
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
            return View(aparelho);
        }

        // GET: Aparelhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aparelho = await _context.Aparelhos
                .FirstOrDefaultAsync(m => m.AparelhosId == id);
            if (aparelho == null)
            {
                return NotFound();
            }

            return View(aparelho);
        }

        // POST: Aparelhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aparelho = await _context.Aparelhos.FindAsync(id);
            _context.Aparelhos.Remove(aparelho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AparelhoExists(int id)
        {
            return _context.Aparelhos.Any(e => e.AparelhosId == id);
        }
    }
}
