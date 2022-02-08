using PcService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.BL.Interfaces
{
    public interface ILaptopService
    {
        Laptop Create(Laptop laptop);
        Laptop Update(Laptop laptop);
        Laptop Delete(int id);
        Laptop GetbyId(int id);
        IEnumerable<Laptop> GetAll();
    }
}
