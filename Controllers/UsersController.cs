using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Models;
using Microsoft.AspNetCore.Http;
using System;
using AutoMapper;
using WebApi.Dto;
using WebApi.Entities;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model, ipAddress());

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            setTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = _userService.RefreshToken(refreshToken, ipAddress());

            if (response == null)
                return Unauthorized(new { message = "Invalid token" });

            setTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [HttpPost("revoke-token")]
        public IActionResult RevokeToken([FromBody] RevokeTokenRequest model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            var response = _userService.RevokeToken(token, ipAddress());

            if (!response)
                return NotFound(new { message = "Token not found" });

            return Ok(new { message = "Token revoked" });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

            [HttpGet("{id}", Name="GetById")]
            public ActionResult <UserReadDto> GetById (Guid id)
            {
                    var userModel = _userService.GetById(id);
                    if(userModel!=null)
                    {
                        return Ok(_mapper.Map<UserReadDto>(userModel));
                    }

                    return NotFound();
            }

        [HttpGet("{id}/refresh-tokens")]
        public IActionResult GetRefreshTokens(Guid id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();

            return Ok(user.RefreshTokens);
        }

        [AllowAnonymous]
        [HttpPost("createuser")]
        public ActionResult<UserReadDto> CreateUser(UserCreateDto usercreateDto)
        {
            User responseModel= null;
            var userModel = _mapper.Map<User>(usercreateDto);
            try
            {
                responseModel = _userService.Create(userModel);
            }
            catch (Exception ex)
            {
                return Ok(new PresentXException(ex.Message));
            }
            var userreadto = _mapper.Map<UserReadDto>(responseModel);
           // return Ok( CreatedAtRoute(nameof(GetById),new {Id = userreadto.Id},userreadto));
           return Ok(userreadto);
        }


        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
