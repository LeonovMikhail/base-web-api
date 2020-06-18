﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace BksTest.ViewModels.User
{
    public class UserListItemViewModel
    {
        public string Login { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Guid> Bookings { get; set; }
        public IEnumerable<Guid> Apartments { get; set; }
    }
}