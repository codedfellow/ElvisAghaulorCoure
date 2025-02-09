﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data
{
    public static class DataSeeder
    {
        public static async Task LoadData(AppDbContext context)
        {
            var countries = await context.Countries.ToListAsync();
            if (countries is not null && countries.Count == 0)
            {
                var countryList = new List<Country>()
                {
                    new Country()
                    {
                        Id = 1,
                        CountryCode = "234",
                        Name = "Nigeria",
                        CountryIso = "NG"
                    },
                    new Country()
                    {
                        Id = 2,
                        CountryCode = "233",
                        Name = "Ghana",
                        CountryIso = "GH"
                    },
                    new Country()
                    {
                        Id = 3,
                        CountryCode = "229",
                        Name = "Benin Republic",
                        CountryIso = "BN"
                    },
                    new Country()
                    {
                        Id = 4,
                        CountryCode = "225",
                        Name = "Côte d'Ivoire",
                        CountryIso = "CIV"
                    }
                };

                await context.Countries.AddRangeAsync(countryList);
                await context.SaveChangesAsync();
            }

            var countryDetails = await context.CountryDetails.ToListAsync();

            if (countryDetails is not null && countryDetails.Count == 0)
            {
                var detailsList = new List<CountryDetail>()
                {
                    new CountryDetail()
                    {
                        Id = 1,
                        CountryId = 1,
                        Operator = "MTN Nigeria",
                        OperatorCode = "MTN NG"
                    },
                    new CountryDetail()
                    {
                        Id = 2,
                        CountryId = 1,
                        Operator = "Airtel Nigeria",
                        OperatorCode = "ANG"
                    },
                    new CountryDetail()
                    {
                        Id = 3,
                        CountryId = 1,
                        Operator = "9 Mobile Nigeria",
                        OperatorCode = "ETN"
                    },
                    new CountryDetail()
                    {
                        Id = 4,
                        CountryId = 1,
                        Operator = "Globacom Nigeria",
                        OperatorCode = "GLO NG"
                    },
                    new CountryDetail()
                    {
                        Id = 5,
                        CountryId = 2,
                        Operator = "Vodafone Ghana",
                        OperatorCode = "Vodafone GH"
                    },
                    new CountryDetail()
                    {
                        Id = 6,
                        CountryId = 2,
                        Operator = "MTN Ghana",
                        OperatorCode = "MTN Ghana"
                    },
                    new CountryDetail()
                    {
                        Id = 7,
                        CountryId = 2,
                        Operator = "Tigo Ghana",
                        OperatorCode = "Tigo Ghana"
                    },
                    new CountryDetail()
                    {
                        Id = 8,
                        CountryId = 3,
                        Operator = "MTN Benin",
                        OperatorCode = "MTN Benin"
                    },
                    new CountryDetail()
                    {
                        Id = 9,
                        CountryId = 3,
                        Operator = "Moov Benin",
                        OperatorCode = "Moov Benin"
                    },
                    new CountryDetail()
                    {
                        Id = 10,
                        CountryId = 4,
                        Operator = "MTN Côte d'Ivoire",
                        OperatorCode = "MTN CIV"
                    }
                };

                await context.CountryDetails.AddRangeAsync(detailsList);
                await context.SaveChangesAsync();
            }
        }
    }
}
