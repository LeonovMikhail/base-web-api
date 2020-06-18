﻿﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BksTest.Handler;
using BksTest.ViewModels.Apartment;
using BksTest.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BksTest.Controllers
{
    [Route("api/apartment")]
    public class ApartmentController : ControllerBase
    {
        
        private readonly IApartmentHandler _apartmentHandler;

        public ApartmentController(IApartmentHandler apartmentHandler)
        {
            _apartmentHandler = apartmentHandler;
        }

        [HttpGet("{id}")]
        public async Task<ApartmentViewModel> Get([FromRoute] Guid id)
        {
            return await _apartmentHandler.GetById(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ApartmentViewModel>> Get()
        {
            return await _apartmentHandler.GetAll();
        }

        [HttpPut]
        public async Task Update([FromBody] ApartmentViewModel model)
        {
            await _apartmentHandler.Update(model);
        }

        [HttpPost]
        public async Task<ApartmentViewModel> Create([FromBody] ApartmentViewModel model)
        {
            return await _apartmentHandler.Create(model);
        }

        [HttpDelete("{id}")]
        public async Task DeleteById([FromRoute] Guid id)
        {
            await _apartmentHandler.Delete(id);
        }
    }
}