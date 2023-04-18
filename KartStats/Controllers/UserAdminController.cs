using System.Threading.Tasks;
using KartStats.BLL;
using KartStats.DAL;
using KartStats.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KartStats.Controllers
{
    [Authorize]
    public class UserAdminController : Controller
    {
        private readonly IKartStatsBLL _IKartStatsBLL;

        public UserAdminController()
        {
            _IKartStatsBLL = new KartStatsBLL(new KartStatsDAL());
        }

        // GET: UserAdmin
        public async Task<IActionResult> Index()
        {
            var users = _IKartStatsBLL.GetDrivers();
            return View(users);
        }

        // GET: UserAdmin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _IKartStatsBLL.GetDriverById(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: UserAdmin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAdmin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Age,Email")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                _IKartStatsBLL.AddDriver(driver);
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        // GET: UserAdmin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _IKartStatsBLL.GetDriverById(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UserAdmin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Age,Email")] Driver driver)
        {
            if (id != driver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _IKartStatsBLL.UpdateDriver(driver);
                }
                catch
                {
                    if (_IKartStatsBLL.GetDriverById(driver.Id) == null)
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

            return View(driver);
        }

        // GET: UserAdmin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _IKartStatsBLL.GetDriverById(id.Value);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UserAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _IKartStatsBLL.DeleteDriver(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
