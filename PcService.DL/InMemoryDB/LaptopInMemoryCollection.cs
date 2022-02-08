using PcService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.DL.InMemoryDB
{
    public static class LaptopInMemoryCollection
    {
        public static List<Laptop> LaptopDB = new List<Laptop>()
        {
            new Laptop()
            {
                Id = 201,
                Name = "Macbook M1",
                Weight = 1.5,
                RatingPricePerformance = Models.Enums.RatingPricePerformance.Great,
                Price = 1950,
            },
            new Laptop()
            {
                Id = 202,
                Name = "Lenovo Legion 5 Pro",
                Weight = 2.5,
                RatingPricePerformance = Models.Enums.RatingPricePerformance.Average,
                Price = 2750,
            },
            new Laptop()
            {
                Id = 203,
                Name = "Acer Aspire 3",
                Weight = 1.7,
                RatingPricePerformance = Models.Enums.RatingPricePerformance.Average,
                Price = 800,
            },
        };
    }
}
