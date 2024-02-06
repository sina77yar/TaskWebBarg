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
    public class CountryService : ICountryService
    {
        private readonly WebBargDbContext dbContext;
        private readonly IMapper mapper;
        public CountryService(WebBargDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<CountryDTO> Add(CountryDTO model)
        {

            var country = mapper.Map<Country>(model);

            await dbContext.Countries.AddAsync(country);
            await dbContext.SaveChangesAsync();

            model.CountryId = country.CountryId;

            return model;
        }
        public List<Country> GetAll()
        {
            var Countries = dbContext.Countries.ToList();

        

            return Countries;
        }
    }
}
