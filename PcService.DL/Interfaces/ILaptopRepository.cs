using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcService.Models.DTO;

namespace PcService.DL.Interfaces
{
    public interface ILaptopRepository
    {
        Laptop Create(Laptop laptop);
        Laptop Update(Laptop laptop);
        Laptop Delete(int id);
        Laptop GetbyId(int id);
        IEnumerable<Laptop> GetAll();       
    }
}
