using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Services;

namespace WebApi.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class PresentsController : ControllerBase
    {

        private readonly IPresentService _service;
        private readonly IMapper _mapper;
        public PresentsController(IPresentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //GET api/presents/{id}
        [HttpGet("{id}", Name = "GetPresentById")]
        public ActionResult<PresentReadDto> GetPresentById(Guid id)
        {
            var PresentItem = _service.GetPresentById(id);
            if (PresentItem != null)
            {
                return Ok(_mapper.Map<PresentReadDto>(PresentItem));
            }

            return NotFound();
        }

        [HttpGet("GetPresentsOfAuth")]
        public ActionResult<IEnumerable<PresentReadDto>> GetAllPresentsOfAuth()
        {
            var UserId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c=>c.Type == "jti" ).Value); 
            var response =  _service.GetAllPresents(UserId);
            if (response == null)
                return BadRequest(new { message = "Not found any presents of the user" });
        
            return Ok(_mapper.Map<IEnumerable<PresentReadDto>>(response));  
        }

        [HttpPost("createpresent")]
        public ActionResult<PresentReadDto> CreatePresent([FromBody]PresentCreateDto presentCreateDto)
        {
            Present responseModel = null;                       
            presentCreateDto.UserId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c=>c.Type == "jti" ).Value);                        
            var presentmodel = _mapper.Map<Present>(presentCreateDto);                        
            try
            {
                responseModel =_service.CreatePresent(presentmodel);
            }
            catch (Exception ex)
            {
                return (Ok(new PresentXException(ex.Message)));
            }
            return Ok(_mapper.Map<PresentReadDto>(responseModel));            
        }




    }
}