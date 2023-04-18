using KartStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartStats.DAL
{
    public interface IKartStatsDAL
    {
        List<Kart> GetKarts();
        Kart GetKartById(int id);
        void AddKart(Kart kart);
        void UpdateKart(Kart kart);
        void DeleteKart(int id);

        List<Driver> GetDrivers();
        Driver GetDriverById(int id);
        void AddDriver(Driver driver);
        void UpdateDriver(Driver driver);
        void DeleteDriver(int id);
    }
}
