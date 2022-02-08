using PcService.BL.Interfaces;
using PcService.DL.Interfaces;
using PcService.Models.DTO;
using Serilog;
using System;
using System.Collections.Generic;

namespace PcService.BL
{
    public class BuyerService : Interfaces.IBuyerService
    {
        private readonly DL.Interfaces.IBuyerRepository _buyerRepository;
        private readonly ILogger _logger;
        public BuyerService(DL.Interfaces.IBuyerRepository buyerRepository, ILogger logger)
        {   
            _buyerRepository = buyerRepository;
            _logger = logger;
        }

        public Buyer Create(Buyer buyer)
        {
            return _buyerRepository.Create(buyer);
        }

        public Buyer Update(Buyer buyer)
        {
            return _buyerRepository.Update(buyer);
        }

        public Buyer Delete(int id)
        {
            return _buyerRepository.Delete(id);
        }

        public Buyer GetbyId(int id)
        {
            return _buyerRepository.GetbyId(id);
        }

        public IEnumerable<Buyer> GetAll()
        {
            _logger.Information("Buyer Get All");
            return _buyerRepository.GetAll();           
        }                  
    }
}
