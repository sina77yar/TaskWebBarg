﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dto
{
    public class CityDTO
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public CountryDTO Country { get; set; }
    }
}
