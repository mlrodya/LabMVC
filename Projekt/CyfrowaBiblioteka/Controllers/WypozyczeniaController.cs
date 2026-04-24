using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CyfrowaBiblioteka.Data;
using CyfrowaBiblioteka.Models;

namespace CyfrowaBiblioteka.Controllers;

public class WypozyczeniaController : Controller
{
    private readonly BibliotekaContext _context;

    public WypozyczeniaController(BibliotekaContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var bibliotekaContext = _context.Wypozyczenie.Include(w => w.Ksiazka);
        return View(await bibliotekaContext.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var wypozyczenie = await _context.Wypozyczenie.Include(w => w.Ksiazka).FirstOrDefaultAsync(m => m.Id == id);
        return wypozyczenie == null ? NotFound() : View(wypozyczenie);
    }

    public IActionResult Create()
    {
        ViewData["KsiazkaId"] = new SelectList(_context.Ksiazka, "Id", "Tytul");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,OsobaWypozyczajaca,DataWypozyczenia,DataZwrotu,KsiazkaId")] Wypozyczenie wypozyczenie)
    {
        if (ModelState.IsValid)
        {
            _context.Add(wypozyczenie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["KsiazkaId"] = new SelectList(_context.Ksiazka, "Id", "Tytul", wypozyczenie.KsiazkaId);
        return View(wypozyczenie);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var wypozyczenie = await _context.Wypozyczenie.FindAsync(id);
        if (wypozyczenie == null) return NotFound();
        ViewData["KsiazkaId"] = new SelectList(_context.Ksiazka, "Id", "Tytul", wypozyczenie.KsiazkaId);
        return View(wypozyczenie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,OsobaWypozyczajaca,DataWypozyczenia,DataZwrotu,KsiazkaId")] Wypozyczenie wypozyczenie)
    {
        if (id != wypozyczenie.Id) return NotFound();
        if (ModelState.IsValid)
        {
            _context.Update(wypozyczenie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["KsiazkaId"] = new SelectList(_context.Ksiazka, "Id", "Tytul", wypozyczenie.KsiazkaId);
        return View(wypozyczenie);
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var wypozyczenie = await _context.Wypozyczenie.Include(w => w.Ksiazka).FirstOrDefaultAsync(m => m.Id == id);
        return wypozyczenie == null ? NotFound() : View(wypozyczenie);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var wypozyczenie = await _context.Wypozyczenie.FindAsync(id);
        if (wypozyczenie != null) _context.Wypozyczenie.Remove(wypozyczenie);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}