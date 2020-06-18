﻿using System;

 namespace WebApp.ViewModels.User
{
    public class UserViewModel
    {
        public Guid? Id { get; set; }
        public string Login { get; set; }
        public string PhoneNumber { get; set; }
    }
}