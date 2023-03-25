﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniEye.Shared.Domain.Domain
{
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetFullName() => $"{FirstName} {LastName}";
    }
}
