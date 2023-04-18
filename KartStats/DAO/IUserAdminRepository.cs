
using KartStats.Models;

namespace KartStats.DAO
{
    public interface IUserAdminRepository
    {
        IEnumerable<UserAdminClass>GetUserAmins();

        Task<UserAdminClass> GetUserAdminDetails(int id);

        Task<UserAdminClass> AddUserAdmin(UserAdminClass userAdmin);

        void UpdateUserAdmin(UserAdminClass userAdmin);

        Task DeleteUserAdmin(int id);
    }
}
