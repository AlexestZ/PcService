using PcService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.DL.Interfaces
{
    public interface IBuyerRepository
    {
        Buyer Create(Buyer buyer);
        Buyer Update(Buyer buyer);
        Buyer Delete(int id);
        Buyer GetbyId(int id);
        IEnumerable<Buyer> GetAll();       
    }
}
