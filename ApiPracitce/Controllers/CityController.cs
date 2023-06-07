using ApiPracitce.Dtos;
using ApiPracitce.Dtos.CategoryDtos;
using ApiPracitce.Dtos.CityDtos;
using ApiPractice.Core.Repositories;
using ApiPractice.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPracitce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly StoreDbContext _context;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityController(StoreDbContext context,ICityRepository cityRepository, IMapper mapper)
        {
            _context = context;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult GetALLCities(int page =1)
        {
            var query = _cityRepository.GetAll(x => true);

            var cityDtos = _mapper.Map<List<CityGetListItemDto>>(query.Skip((page - 1) * 4).Take(4).ToList());

            PaginatedListDto<CityGetListItemDto> model = new PaginatedListDto<CityGetListItemDto>(cityDtos, page, 4, query.Count());

            return Ok(model);

        }
    }
}
