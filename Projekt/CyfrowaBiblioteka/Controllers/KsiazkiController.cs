using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CyfrowaBiblioteka.Data;
using CyfrowaBiblioteka.Models;

namespace CyfrowaBiblioteka.Controllers;

public class KsiazkiController : Controller
{
    private readonly BibliotekaContext _context;

    public KsiazkiController(BibliotekaContext context)
    {
        _context = context;
    }

    // GET: Ksiazki (Тут ми додали пошук і фільтр)
    public async Task<IActionResult> Index(int? searchAutor, string searchString)
    {
        var ksiazki = _context.Ksiazka.Include(k => k.Autor).AsQueryable();

        if (!string.IsNullOrEmpty(searchString))
        {
            ksiazki = ksiazki.Where(s => s.Tytul!.ToUpper().Contains(searchString.ToUpper()));
        }

        if (searchAutor.HasValue)
        {
            ksiazki = ksiazki.Where(x => x.AutorId == searchAutor.Value);
        }

        // ЗВЕРНИ УВАГУ: тут ми кажемо використовувати "PelneImie" для списку авторів
        ViewData["searchAutor"] = new SelectList(_context.Autor, "Id", "PelneImie");

        return View(await ksiazki.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var ksiazka = await _context.Ksiazka.Include(k => k.Autor).FirstOrDefaultAsync(m => m.Id == id);
        return ksiazka == null ? NotFound() : View(ksiazka);
    }

    public IActionResult Create()
    {
        // Тут теж кажемо використовувати "PelneImie" у випадаючому списку
        ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "PelneImie");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Tytul,RokWydania,Gatunek,AutorId")] Ksiazka ksiazka)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ksiazka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "PelneImie", ksiazka.AutorId);
        return View(ksiazka);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var ksiazka = await _context.Ksiazka.FindAsync(id);
        if (ksiazka == null) return NotFound();
        ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "PelneImie", ksiazka.AutorId);
        return View(ksiazka);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Tytul,RokWydania,Gatunek,AutorId")] Ksiazka ksiazka)
    {
        if (id != ksiazka.Id) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(ksiazka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["AutorId"] = new SelectList(_context.Autor, "Id", "PelneImie", ksiazka.AutorId);
        return View(ksiazka);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var ksiazka = await _context.Ksiazka.Include(k => k.Autor).FirstOrDefaultAsync(m => m.Id == id);
        return ksiazka == null ? NotFound() : View(ksiazka);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var ksiazka = await _context.Ksiazka.FindAsync(id);
        if (ksiazka != null) _context.Ksiazka.Remove(ksiazka);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}