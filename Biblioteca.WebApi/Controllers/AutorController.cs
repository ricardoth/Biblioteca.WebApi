using AutoMapper;
using Biblioteca.Domain;
using Biblioteca.Domain.CustomEntities;
using Biblioteca.Domain.DTOs;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Domain.QueryFilters;
using Biblioteca.Infraestructure.Interfaces;
using Biblioteca.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public AutorController(IAutorService autorService, IMapper mapper, IUriService uriService)
        {
            _autorService = autorService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet(Name = nameof(GetAutores))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAutores([FromQuery]AutorQueryFilter filtros)
        {
            var autores = _autorService.GetAutores(filtros);
            var autoresDtos = _mapper.Map<IEnumerable<AutorDto>>(autores);

            var metaData = new MetaData
            {
                TotalCount = autores.TotalCount,
                PageSize = autores.PageSize,
                CurrentPage = autores.CurrentPage,
                TotalPages = autores.TotalPages,
                HasNextPage = autores.HasNextPage,
                HasPreviousPage = autores.HasPreviousPage,
                NextPageUrl = _uriService.GetAutorPaginationUri(filtros, Url.RouteUrl(nameof(GetAutores))).ToString(),
                PreviousPageUrl = _uriService.GetAutorPaginationUri(filtros, Url.RouteUrl(nameof(GetAutores))).ToString()
            };

            var response = new ApiResponse<IEnumerable<AutorDto>>(autoresDtos)
            {
                Meta = metaData
            };

            Response.Headers.Add("x-Pagination", JsonConvert.SerializeObject(metaData));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var autor = await _autorService.GetAutor(id);
            var autorDto = _mapper.Map<AutorDto>(autor);
            var response = new ApiResponse<AutorDto>(autorDto);
            return Ok(response);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] AutorDto autorDto)
        {
            var autor = _mapper.Map<Autor>(autorDto);
            await _autorService.Agregar(autor);
            autorDto = _mapper.Map<AutorDto>(autor);
            var response = new ApiResponse<AutorDto>(autorDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, AutorDto autorDto)
        { 
            var autor = _mapper.Map<Autor>(autorDto);
            autor.Id = id;
            var result = await _autorService.Actualizar(autor);

            var response = new ApiResponse<bool>(result);
            return Ok(response);    
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _autorService.Eliminar(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
