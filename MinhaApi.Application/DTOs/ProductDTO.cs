using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApi.Application.DTOs
{
    public class ProductDTO
    {
        public int It { get; set; }
        public string Name { get; set; }
        public string CodErp{ get; set; }
        public decimal Price{ get; set; }
    }
}
