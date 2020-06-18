using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BksTest.DAL.Repository;
using BksTest.Domain.Models;
using BksTest.Handler;
using BksTest.ViewModels.Apartment;

namespace BksTest.Service.Implementation
{
    public class ApartmentService : IApartmentService
    {
        private readonly IRepository<ApartmentModel> _apartmentRepository;
        private readonly IMapper _mapper;

        public ApartmentService(IRepository<ApartmentModel> apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        public async Task<ApartmentViewModel> GetById(Guid id)
        {
            var apartment = await _apartmentRepository.GetById(id);
            return _mapper.Map<ApartmentModel, ApartmentViewModel>(apartment);
        }

        public async Task<IEnumerable<ApartmentViewModel>> GetAll()
        {
            var apartments = await _apartmentRepository.Get();
            return apartments.Select(a => _mapper.Map<ApartmentModel, ApartmentViewModel>(a));
        }

        public async Task Update(ApartmentViewModel model)
        {
            var apartment = _mapper.Map<ApartmentViewModel, ApartmentModel>(model);
            await _apartmentRepository.Update(apartment);
        }

        public async Task<ApartmentViewModel> Create(ApartmentViewModel model)
        {
            var apartment = _mapper.Map<ApartmentViewModel, ApartmentModel>(model);
            await _apartmentRepository.Create(apartment);
            return _mapper.Map<ApartmentModel, ApartmentViewModel>(apartment);
        }

        public async Task Delete(Guid id)
        {
            await _apartmentRepository.Delete(id);
        }
    }
}