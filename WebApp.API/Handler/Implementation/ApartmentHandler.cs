using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Service;
using WebApp.ViewModels.Apartment;

namespace WebApp.Handler.Implementation
{
    public class ApartmentHandler : IApartmentHandler
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentHandler(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        public async Task<ApartmentViewModel> GetById(Guid id)
        {
            return await _apartmentService.GetById(id);
        }

        public async Task<IEnumerable<ApartmentViewModel>> GetAll()
        {
            return await _apartmentService.GetAll();
        }

        public async Task Update(ApartmentViewModel model)
        {
            await _apartmentService.Update(model);
        }

        public async Task<ApartmentViewModel> Create(ApartmentViewModel model)
        {
            return await _apartmentService.Create(model);
        }

        public async Task Delete(Guid id)
        {
            await _apartmentService.Delete(id);
        }
    }
}