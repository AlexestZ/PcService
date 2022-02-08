using PcService.DL.InMemoryDB.Repositories;
using PcService.DL.Interfaces;
using PcService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.DL.Repositories.InMemoryRepositories
{
    public class PersonalComputerInMemoryRepository : Interfaces.IPersonalComputerRepository
    {
        public PersonalComputerInMemoryRepository()
        {

        }
        public PersonalComputer Create(PersonalComputer personalComputer)
        {
            PersonalComputerInMemoryCollection.PersonalComputerDB.Add(personalComputer);
            return personalComputer;
        }

        public PersonalComputer Delete(int id)
        {
            var personalComputer = PersonalComputerInMemoryCollection.PersonalComputerDB.FirstOrDefault(personalComputer => personalComputer.Id == id);

            PersonalComputerInMemoryCollection.PersonalComputerDB.Remove(personalComputer);
            return personalComputer;
        }

        public IEnumerable<PersonalComputer> GetAll()
        {
            return PersonalComputerInMemoryCollection.PersonalComputerDB;
        }

        public PersonalComputer GetbyId(int id)
        {
            return PersonalComputerInMemoryCollection.PersonalComputerDB.FirstOrDefault(x => x.Id == id);
        }

        public PersonalComputer Update(PersonalComputer personalComputer)
        {
            var result = PersonalComputerInMemoryCollection.PersonalComputerDB.FirstOrDefault(x => x.Id == personalComputer.Id);
            result.Name = personalComputer.Name;
            result.RatingPricePerformance = personalComputer.RatingPricePerformance;
            result.Price = personalComputer.Price;
            return personalComputer;
        }
    }
}
