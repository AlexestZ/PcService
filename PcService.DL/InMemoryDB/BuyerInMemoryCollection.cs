using PcService.DL.Repositories.InMemoryRepositories;
using PcService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.DL.InMemoryDB
{
    public static class BuyerInMemoryCollection
    {
        public static List<Buyer> BuyerDB = new List<Buyer>()
        {
            new Buyer()
            {
                Id = 1,
                Name = "Ivan",
                Interests = "Programming",
                Budget = 3000
            },
            new Buyer()
            {
                Id = 2,
                Name = "Dimitur",
                Interests = "HomeMedia",
                Budget = 1000
            },
             new Buyer()
            {
                Id = 3,
                Name = "Aleksandar",
                Interests = "Gaming",
                Budget = 3000
            }
        };
    }
}
