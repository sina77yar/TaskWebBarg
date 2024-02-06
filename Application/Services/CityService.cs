using Application.Interfaces;
using AutoMapper;
using Core.Entities;
using Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CityService : ICityService
    {
        private readonly WebBargDbContext dbContext;
        private readonly IMapper mapper;
        public CityService(WebBargDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<CityDTO> Add(CityDTO model)
        {

            var city = mapper.Map<City>(model);

            await dbContext.Cities.AddAsync(city);
            await dbContext.SaveChangesAsync();
            
            model.CityId = city.CityId;

            return model;
        }
        public List<City> GetAll()
        {
            var Cities = dbContext.Cities.ToList();

            return Cities;
        }
    }
}
