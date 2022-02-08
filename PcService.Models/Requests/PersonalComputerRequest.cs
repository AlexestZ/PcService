using PcService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.Models.Requests
{
    public class PersonalComputerRequest
    {
        public string Name { get; set; }
        public RatingPricePerformance RatingPricePerformance { get; set; }
        public double Price { get; set; }
    }
}
