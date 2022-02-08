using PcService.BL.Interfaces;
using PcService.DL.Interfaces;
using PcService.Models.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.BL.Services
{
    public class laptopService : Interfaces.ILaptopService
    {
        private readonly DL.Interfaces.ILaptopRepository _laptopRepository;
        private readonly ILogger _logger;

        public laptopService(DL.Interfaces.ILaptopRepository laptopRepository, ILogger logger)
        {
            _laptopRepository = laptopRepository;
            _logger = logger;
        }

        public Laptop Create(Laptop laptop)
        {
           return _laptopRepository.Create(laptop);
        }

        public Laptop Delete(int id)
        {
            return _laptopRepository.Delete(id);
        }

        public IEnumerable<Laptop> GetAll()
        {
            return _laptopRepository.GetAll();
        }

        public Laptop GetbyId(int id)
        {
            return _laptopRepository.GetbyId(id);
        }

        public Laptop Update(Laptop laptop)
        {
           return _laptopRepository.Update(laptop);
        }
    }
}
