﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BksTest.DAL.Repository;
using BksTest.Domain.Models;
using BksTest.Handler;
using BksTest.ViewModels.User;

namespace BksTest.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Create(UserViewModel model)
        {
            var domain = _mapper.Map<UserViewModel, UserModel>(model);
            await _userRepository.Create(domain);

            return _mapper.Map<UserModel, UserViewModel>(domain);
        }


        public async Task<UserViewModel> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);

            return _mapper.Map<UserModel, UserViewModel>(user);
        }

        public async Task<IEnumerable<UserListItemViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.Select(u => _mapper.Map<UserModel, UserListItemViewModel>(u));
        }

        public async Task<IEnumerable<UserViewModel>> Get()
        {
            var users = await _userRepository.Get();
            return users.Select(w => _mapper.Map<UserModel, UserViewModel>(w));
        }

        public async Task Update(UserViewModel model)
        {
            var user = _mapper.Map<UserViewModel, UserModel>(model);
            await _userRepository.Update(user);
        }

        public async Task Delete(Guid id)
        {
            await _userRepository.Delete(id);
        }
    }
}