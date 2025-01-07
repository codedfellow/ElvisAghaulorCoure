using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class NumberResponseDto
    {
        public string Number { get; set; }
        public CountryDto? Country { get; set; }
    }
}
