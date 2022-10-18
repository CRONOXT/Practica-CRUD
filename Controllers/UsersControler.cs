﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica_CRUD.Class;
using Practica_CRUD.Class.ClassDto;
using Practica_CRUD.Data;
using Practica_CRUD.Services;

namespace Practica_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersControler : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UserServices _userServices;
        public UsersControler(DataContext dataContext,UserServices userServices)
        {
            _dataContext = dataContext;
            _userServices = userServices;
        }
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userServices.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var user = await _userServices.GetById(id);

            if(user is null)
                 return NotFound(id);
            
            return user;
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserDto user)
        {
            var newUser = await _userServices.Create(user);
            return CreatedAtAction(nameof(GetById),new { id = newUser.Id }, newUser);
        }
    }
}