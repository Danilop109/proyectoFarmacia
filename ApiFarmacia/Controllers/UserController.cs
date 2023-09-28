using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public UserController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this._mapper = mapper;
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

    }
}