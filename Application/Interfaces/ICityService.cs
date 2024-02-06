using Core.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICityService
    {
        List<City> GetAll();
        Task<CityDTO> Add(CityDTO model);
    }
}
