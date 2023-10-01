using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApiFarmacia.Dtos;
using ApiFarmacia.Services;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiFarmacia.Controllers
{

    public class UserController : BaseApiController
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserService userService;

        public UserController(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = mapper;
            this.userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var llamado = await unitOfWork.Users.GetAllAsync();
            return Ok(llamado);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> Get(int id)
        {
            var llamado = await unitOfWork.Users.GetByIdAsync(id);
            return Ok(llamado);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<User>> Post(User user)
        {
            this.unitOfWork.Users.Add(user);
            await unitOfWork.SaveAsync();
            if (user == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Post), new { id = user.Id }, user);
        }

        [HttpPost("register")]

        public async Task<ActionResult> RegisterAsync(RegisterDto model)
        {
            var result = await userService.RegisterAsync(model);
            return Ok(result);
        }


        [HttpPost("token")]
        public async Task<ActionResult> RegisterAsync(LoginDto model)
        {
            var result = await userService.GetTokenAsync(model);
            return Ok(result);
        }

        [HttpPost("addrole")]

        public async Task<ActionResult> AddRoleAsync(AddRolDto model)
        {
            var result = await userService.AddRoleAsync(model);
            return Ok(result);
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await userService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRefreshTokenInCookie(response.RefreshToken);
            return Ok(response);
        }



        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<User>> Put(int id, [FromBody] User user)
        {
            if (user == null)
                return NotFound();
            unitOfWork.Users.Update(user);
            await unitOfWork.SaveAsync();
            return user;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Delete(int id)
        {
            var llamado = await unitOfWork.Users.GetByIdAsync(id);
            if (llamado == null)
            {
                return NotFound();
            }
            unitOfWork.Users.Remove(llamado);
            await unitOfWork.SaveAsync();
            return NoContent();
        }


        private void SetRefreshTokenInCookie(string refreshToken)
        {
        var cookieOptions = new CookieOptions
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(10),
        };
        Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }


    }
}