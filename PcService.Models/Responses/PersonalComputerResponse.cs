using PcService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.Models.Responses
{
    public class PersonalComputerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RatingPricePerformance RatingPricePerformance { get; set; }
        public double Price { get; set; }
    }
}
