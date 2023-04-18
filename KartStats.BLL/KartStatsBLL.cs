using KartStats.DAL;
using KartStats.Models;

namespace KartStats.BLL
{
    public class KartStatsBLL : IKartStatsBLL
    {
        private IKartStatsDAL dal;

        public KartStatsBLL(IKartStatsDAL dal)
        {
            this.dal = dal;
        }

        public List<Kart> GetKarts()
        {
            return dal.GetKarts();
        }

        public Kart GetKartById(int id)
        {
            return dal.GetKartById(id);
        }

        public void AddKart(Kart kart)
        {
            if (string.IsNullOrEmpty(kart.Model))
            {
                throw new ArgumentException("Model name is required.");
            }

            if (string.IsNullOrEmpty(kart.Brand))
            {
                throw new ArgumentException("Brand name is required.");
            }

            if (kart.MaxSpeed == null || kart.MaxSpeed == 0)
            {
                throw new ArgumentException("Maximum speed is required.");
            }

            dal.AddKart(kart);
        }

        public void UpdateKart(Kart kart)
        {
            if (string.IsNullOrEmpty(kart.Model))
            {
                throw new ArgumentException("Model name is required.");
            }

            if (string.IsNullOrEmpty(kart.Brand))
            {
                throw new ArgumentException("Brand name is required.");
            }

            if (kart.MaxSpeed == null || kart.MaxSpeed == 0)
            {
                throw new ArgumentException("Maximum speed is required.");
            }

            dal.UpdateKart(kart);
        }

        public void DeleteKart(int id)
        {
            dal.DeleteKart(id);
        }

        public List<Driver> GetDrivers()
        {
            return dal.GetDrivers();
        }

        public Driver GetDriverById(int id)
        {
            return dal.GetDriverById(id);
        }

        public void AddDriver(Driver driver)
        {
            if (string.IsNullOrEmpty(driver.FirstName))
            {
                throw new ArgumentException("FirstName is required.");
            }

            if (string.IsNullOrEmpty(driver.LastName))
            {
                throw new ArgumentException("LastName is required.");
            }

            dal.AddDriver(driver);
        }

        public void UpdateDriver(Driver driver)
        {
            if (string.IsNullOrEmpty(driver.FirstName))
            {
                throw new ArgumentException("FirstName is required.");
            }

            if (string.IsNullOrEmpty(driver.LastName))
            {
                throw new ArgumentException("LastName is required.");
            }

            dal.UpdateDriver(driver);
        }

        public void DeleteDriver(int id)
        {
            dal.DeleteDriver(id);
        }
    }
}