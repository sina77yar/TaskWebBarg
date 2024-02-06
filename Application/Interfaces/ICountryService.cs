using Core.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICountryService
    {
        List<Country> GetAll();
        Task<CountryDTO> Add(CountryDTO model);
    }
}
