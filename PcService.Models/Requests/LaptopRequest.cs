using PcService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.Models.Requests
{
    public class LaptopRequest
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public RatingPricePerformance RatingPricePerformance { get; set; }
        public double Price { get; set; }
    }
}
