using ApiPracitce.Dtos;
using ApiPracitce.Dtos.CategoryDtos;
using ApiPracitce.Dtos.CityDtos;
using ApiPractice.Core.Entities;
using ApiPractice.Core.Repositories;
using ApiPractice.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ApiPracitce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CitiesController(StoreDbContext context,ICityRepository cityRepository, IMapper mapper)
        {
            _context = context;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult GetALLCities(int page = 1)
        {
            var query = _cityRepository.GetAll(x => true);

            var cityDtos = _mapper.Map<List<CityGetListItemDto>>(query.Skip((page - 1) * 4).Take(4).ToList());

            PaginatedListDto<CityGetListItemDto> model = new PaginatedListDto<CityGetListItemDto>(cityDtos, page, 4, query.Count());

            return Ok(model);

        }

        [HttpGet("All")]
        public IActionResult GetAllCitiesSimple()
        {
            var query = _cityRepository.GetAll(x => true);

            var cityDtos = _mapper.Map<List<CityGetListItemDto>>(query.ToList());

            return Ok(cityDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            City city = await _cityRepository.GetAsync(x => x.Id == id);

            if (city == null) return NotFound();

            CityGetDto CityDto = _mapper.Map<CityGetDto>(city);

            return Ok(CityDto);
        }

    }
}
