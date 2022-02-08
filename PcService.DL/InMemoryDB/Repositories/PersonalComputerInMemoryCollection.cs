using PcService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.DL.InMemoryDB.Repositories
{
    public static class PersonalComputerInMemoryCollection
    {
        public static List<PersonalComputer> PersonalComputerDB = new List<PersonalComputer>()
        {
            new PersonalComputer()
            {
                Id = 101,
                Name ="Asus ROG RTX",
                RatingPricePerformance =Models.Enums.RatingPricePerformance.Average,
                Price = 2900
            },
            new PersonalComputer()
            {
                Id = 102,
                Name ="IMac Pro",
                RatingPricePerformance =Models.Enums.RatingPricePerformance.Great,
                Price = 1900
            },
            new PersonalComputer()
            {
                Id = 103,
                Name ="Dell Office Series",
                RatingPricePerformance =Models.Enums.RatingPricePerformance.Bad,
                Price = 900
            },
        };
    }
}
