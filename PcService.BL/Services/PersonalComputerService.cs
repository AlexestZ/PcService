using PcService.BL.Interfaces;
using PcService.DL.Interfaces;
using PcService.DL.Repositories.InMemoryRepositories;
using PcService.Models.DTO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.BL.Services
{
   public class PersonalComputerService : Interfaces.IPersonalComputerService
    {
        private readonly DL.Interfaces.IPersonalComputerRepository _personalComputerRepository;
        private readonly ILogger _logger;
        public PersonalComputerService(DL.Interfaces.IPersonalComputerRepository personalComputerRepository, ILogger logger)
        {
            _personalComputerRepository = personalComputerRepository;
            _logger = logger;
        }

        public PersonalComputer Create(PersonalComputer personalComputer)
        {
            return _personalComputerRepository.Create(personalComputer);
        }

        public PersonalComputer Delete(int id)
        {
            return _personalComputerRepository.Delete(id);
        }

        public IEnumerable<PersonalComputer> GetAll()
        {
            return _personalComputerRepository.GetAll();
        }

        public PersonalComputer GetbyId(int id)
        {
            return _personalComputerRepository.GetbyId(id);
        }

        public PersonalComputer Update(PersonalComputer personalComputer)
        {
            return _personalComputerRepository.Update(personalComputer);
        }
    }
}
