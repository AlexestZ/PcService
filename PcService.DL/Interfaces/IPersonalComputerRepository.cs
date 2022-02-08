using PcService.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.DL.Interfaces
{
    public interface IPersonalComputerRepository
    {
        PersonalComputer Create(PersonalComputer personalComputer);
        PersonalComputer Update(PersonalComputer personalComputer);
        PersonalComputer Delete(int id);
        PersonalComputer GetbyId(int id);
        IEnumerable<PersonalComputer> GetAll();
    }
}
