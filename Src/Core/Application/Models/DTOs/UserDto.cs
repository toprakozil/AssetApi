﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTOs
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; } = null!;
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedUser { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedUser { get; set; }
    }
}
