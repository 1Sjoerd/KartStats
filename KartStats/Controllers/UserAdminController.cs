using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KartStats.Data;
using KartStats.Models;
using Microsoft.AspNetCore.Authorization;

namespace KartStats.Controllers
{
    [Authorize]
    public class UserAdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserAdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserAdmin
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserAdmin.ToListAsync());
        }

        // GET: UserAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserAdmin == null)
            {
                return NotFound();
            }

            var userAdminClass = await _context.UserAdmin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAdminClass == null)
            {
                return NotFound();
            }

            return View(userAdminClass);
        }

        // GET: UserAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mobile,Email,Source")] UserAdminClass userAdminClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAdminClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userAdminClass);
        }

        // GET: UserAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserAdmin == null)
            {
                return NotFound();
            }

            var userAdminClass = await _context.UserAdmin.FindAsync(id);
            if (userAdminClass == null)
            {
                return NotFound();
            }
            return View(userAdminClass);
        }

        // POST: UserAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mobile,Email,Source")] UserAdminClass userAdminClass)
        {
            if (id != userAdminClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAdminClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAdminClassExists(userAdminClass.Id))
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
            return View(userAdminClass);
        }

        // GET: UserAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserAdmin == null)
            {
                return NotFound();
            }

            var userAdminClass = await _context.UserAdmin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAdminClass == null)
            {
                return NotFound();
            }

            return View(userAdminClass);
        }

        // POST: UserAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserAdmin == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserAdmin'  is null.");
            }
            var userAdminClass = await _context.UserAdmin.FindAsync(id);
            if (userAdminClass != null)
            {
                _context.UserAdmin.Remove(userAdminClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAdminClassExists(int id)
        {
          return _context.UserAdmin.Any(e => e.Id == id);
        }
    }
}
