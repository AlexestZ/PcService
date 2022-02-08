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
    public class BuyerInMemoryRepository : IBuyerRepository
    {
        public BuyerInMemoryRepository()
        {
        }
        public Buyer Create(Buyer buyer)
        {
            BuyerInMemoryCollection.BuyerDB.Add(buyer);
            return buyer;
        }

        public Buyer Delete(int id)
        {
            var buyer = BuyerInMemoryCollection.BuyerDB.FirstOrDefault(buyer => buyer.Id == id);

            BuyerInMemoryCollection.BuyerDB.Remove(buyer);
            return buyer;
        }

        public IEnumerable<Buyer> GetAll()
        {
            return BuyerInMemoryCollection.BuyerDB;
        }

        public Buyer GetbyId(int id)
        {
            return BuyerInMemoryCollection.BuyerDB.FirstOrDefault(x => x.Id == id);           
        }

        public Buyer Update(Buyer buyer)
        {
            var result = BuyerInMemoryCollection.BuyerDB.FirstOrDefault(x => x.Id == buyer.Id);
            result.Name = buyer.Name;
            result.Interests = buyer.Interests;
            result.Budget = buyer.Budget;
            return result;
        }
    }
}
