using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Academia.Models;

namespace Academia.Controllers
{
    public class TreinoExercicioController : Controller
    {
        private readonly AcademiaContext _context;

        public TreinoExercicioController(AcademiaContext context)
        {
            _context = context;
        }

        // GET: TreinoExercicio
        public async Task<IActionResult> Index()
        {
            var academiaContext = _context.TreinoExercicio.Include(t => t.Exercicio).Include(t => t.Treino);
            return View(await academiaContext.ToListAsync());
        }

        // GET: TreinoExercicio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinoExercicio = await _context.TreinoExercicio
                .Include(t => t.Exercicio)
                .Include(t => t.Treino)
                .FirstOrDefaultAsync(m => m.TreinoExercicioId == id);
            if (treinoExercicio == null)
            {
                return NotFound();
            }

            return View(treinoExercicio);
        }

        // GET: TreinoExercicio/Create
        public IActionResult Create()
        {
            ViewData["ExercicioId"] = new SelectList(_context.Exercicio, "ExercicioId", "Descricao");
            ViewData["TreinoId"] = new SelectList(_context.Treino, "TreinoId", "Descricao");
            return View();
        }

        // POST: TreinoExercicio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreinoExercicioId,TreinoId,ExercicioId,TempoMax")] TreinoExercicio treinoExercicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treinoExercicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExercicioId"] = new SelectList(_context.Exercicio, "ExercicioId", "ExercicioId", treinoExercicio.ExercicioId);
            ViewData["TreinoId"] = new SelectList(_context.Treino, "TreinoId", "Descricao", treinoExercicio.TreinoId);
            return View(treinoExercicio);
        }

        // GET: TreinoExercicio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinoExercicio = await _context.TreinoExercicio.FindAsync(id);
            if (treinoExercicio == null)
            {
                return NotFound();
            }
            ViewData["ExercicioId"] = new SelectList(_context.Exercicio, "ExercicioId", "ExercicioId", treinoExercicio.ExercicioId);
            ViewData["TreinoId"] = new SelectList(_context.Treino, "TreinoId", "Descricao", treinoExercicio.TreinoId);
            return View(treinoExercicio);
        }

        // POST: TreinoExercicio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreinoExercicioId,TreinoId,ExercicioId,TempoMax")] TreinoExercicio treinoExercicio)
        {
            if (id != treinoExercicio.TreinoExercicioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treinoExercicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinoExercicioExists(treinoExercicio.TreinoExercicioId))
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
            ViewData["ExercicioId"] = new SelectList(_context.Exercicio, "ExercicioId", "ExercicioId", treinoExercicio.ExercicioId);
            ViewData["TreinoId"] = new SelectList(_context.Treino, "TreinoId", "Descricao", treinoExercicio.TreinoId);
            return View(treinoExercicio);
        }

        // GET: TreinoExercicio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treinoExercicio = await _context.TreinoExercicio
                .Include(t => t.Exercicio)
                .Include(t => t.Treino)
                .FirstOrDefaultAsync(m => m.TreinoExercicioId == id);
            if (treinoExercicio == null)
            {
                return NotFound();
            }

            return View(treinoExercicio);
        }

        // POST: TreinoExercicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var treinoExercicio = await _context.TreinoExercicio.FindAsync(id);
            _context.TreinoExercicio.Remove(treinoExercicio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinoExercicioExists(int id)
        {
            return _context.TreinoExercicio.Any(e => e.TreinoExercicioId == id);
        }
    }
}
