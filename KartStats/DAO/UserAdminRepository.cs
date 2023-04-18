using KartStats.Data;
using KartStats.Models;
using Microsoft.EntityFrameworkCore;

namespace KartStats.DAO
{
    public class UserAdminRepository : IUserAdminRepository
    {
        ApplicationDbContext _context;
        public UserAdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserAdminClass> AddUserAdmin(UserAdminClass userAdmin)
        {
            _context.Add(userAdmin);
            await _context.SaveChangesAsync();
            return userAdmin;
        }

        public async Task DeleteUserAdmin(int id)
        {
            var userAdminClass = await _context.UserAdmin.FindAsync(id);
            _context.UserAdmin.Remove(userAdminClass);
            await _context.SaveChangesAsync();

        }

        public async Task<UserAdminClass> GetUserAdminDetails(int id)
        {
            var userAdminClass = await _context.UserAdmin.FindAsync(id);
            _context.UserAdmin.Remove(userAdminClass);
            return userAdminClass;
        }

        public IEnumerable<UserAdminClass> GetUserAmins()
        {
            return _context.UserAdmin.ToList();
        }

        public void UpdateUserAdmin(UserAdminClass userAdmin)
        {
            _context.Update(userAdmin);
        }
    }
}
