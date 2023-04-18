using KartStats.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartStats.DAL
{
    public class KartStatsDAL : IKartStatsDAL
    {
        private KartStatsContext context = new KartStatsContext();

        public List<Kart> GetKarts()
        {
            return context.Karts.ToList();
        }

        public Kart GetKartById(int id)
        {
            return context.Karts.Find(id);
        }

        public void AddKart(Kart kart)
        {
            context.Karts.Add(kart);
            context.SaveChanges();
        }

        public void UpdateKart(Kart kart)
        {
            context.Entry(kart).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteKart(int id)
        {
            var kart = context.Karts.Find(id);
            context.Karts.Remove(kart);
            context.SaveChanges();
        }

        public List<Driver> GetDrivers()
        {
            return context.Drivers.ToList();
        }

        public Driver GetDriverById(int id)
        {
            return context.Drivers.Find(id);
        }

        public void AddDriver(Driver driver)
        {
            context.Drivers.Add(driver);
            context.SaveChanges();
        }

        public void UpdateDriver(Driver driver)
        {
            context.Entry(driver).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDriver(int id)
        {
            var driver = context.Drivers.Find(id);
            context.Drivers.Remove(driver);
            context.SaveChanges();
        }
    }
}
