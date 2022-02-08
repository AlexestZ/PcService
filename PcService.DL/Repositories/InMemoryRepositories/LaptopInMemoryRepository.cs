using PcService.DL.InMemoryDB;
using PcService.DL.Interfaces;
using PcService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.DL.Repositories.InMemoryRepositories
{
    public class LaptopInMemoryRepository : Interfaces.ILaptopRepository
    {
        public LaptopInMemoryRepository()
        {

        }
        public Laptop Create(Laptop laptop)
        {
           LaptopInMemoryCollection.LaptopDB.Add(laptop);
            return laptop;
        }

        public Laptop Delete(int id)
        {
            var laptop = LaptopInMemoryCollection.LaptopDB.FirstOrDefault(laptop => laptop.Id == id);

            LaptopInMemoryCollection.LaptopDB.Remove(laptop);
            return laptop;
        }

        public IEnumerable<Laptop> GetAll()
        {
            return LaptopInMemoryCollection.LaptopDB;
        }

        public Laptop GetbyId(int id)
        {
            return LaptopInMemoryCollection.LaptopDB.FirstOrDefault(x => x.Id == id);
        }

        public Laptop Update(Laptop laptop)
        {
            var result = LaptopInMemoryCollection.LaptopDB.FirstOrDefault(x => x.Id == laptop.Id);
            result.Name = laptop.Name;
            result.Weight = laptop.Weight;
            result.RatingPricePerformance = laptop.RatingPricePerformance;
            result.Price = laptop.Price;
            return result;
        }

       
    }
}
