﻿﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BksTest.Domain.Models;
using BksTest.Handler;
using BksTest.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger;

namespace BksTest.Controllers
{
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _userHandler;

        public UserController(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        [HttpGet("{id}")]
        public async Task<UserViewModel> Get([FromRoute] Guid id)
        {
            return await _userHandler.GetById(id);
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<UserListItemViewModel>> GetAll()
        {
            return await _userHandler.GetAll();
        }
        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> Get()
        {
            return await _userHandler.Get();
        }

        [HttpPut]
        public async Task Update([FromBody] UserViewModel model)
        {
            await _userHandler.Update(model);
        }

        [HttpPost]
        public async Task<UserViewModel> Create([FromBody] UserViewModel model)
        {
            return await _userHandler.Create(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] Guid id)
        {
            await _userHandler.Delete(id);
        }
    }
}