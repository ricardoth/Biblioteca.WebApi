using AutoMapper;
using Biblioteca.Domain;
using Biblioteca.Domain.DTOs;
using Biblioteca.Domain.Interfaces;
using Biblioteca.WebApi.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;
        private readonly IMapper _mapper;

        public AutorController(IAutorService autorService, IMapper mapper)
        {
            _autorService = autorService;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(GetAutores))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAutores()
        {
            var autores = _autorService.GetAutores();
            if (autores != null) {
                var autoresDto = _mapper.Map<List<AutorDto>>(autores);
                var response = new ApiResponse<List<AutorDto>>(autoresDto);
                return Ok(response);
            }

            return BadRequest();
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
