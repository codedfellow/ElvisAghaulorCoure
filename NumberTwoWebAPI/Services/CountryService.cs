using Contracts;
using Data;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CountryService : ICountryService
    {
        private readonly AppDbContext _context;
        public CountryService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<NumberResponseDto> GetNumberInformation(string phoneNumber)
        {
            string countryCode = phoneNumber.Substring(0, 3);

            if (phoneNumber.StartsWith("+"))
            {
                countryCode = phoneNumber.Substring(1, 3);
            }

            var country = await _context.Countries.FirstOrDefaultAsync(c => c.CountryCode == countryCode);

            if (country is not null)
            {
                var response = new NumberResponseDto() {
                    Number = phoneNumber,
                    Country = (from con in _context.Countries
                              where con.Id == country.Id
                              select new CountryDto
                              {
                                  CountryCode = con.CountryCode,
                                  CountryIso = con.CountryIso,
                                  Name = con.Name,
                                  CountryDetails = (from det in _context.CountryDetails
                                                   where det.CountryId == con.Id
                                                   select new CountryDetailsDto
                                                   {
                                                       OperatorCode = det.OperatorCode,
                                                       Operator = det.Operator
                                                   }).ToList()
                              }).FirstOrDefault()
                };

                return response;
            }

            return  new NumberResponseDto()
            {
                Number = phoneNumber,
                Country = null
            };
        }
    }
}
