using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcService.Models.Responses
{
    public class BuyerResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Interests { get; set; }
        public double Budget { get; set; }
    }
}
