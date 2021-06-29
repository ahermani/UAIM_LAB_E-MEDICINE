//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Patterns.Application.Model
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

    public class PatientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Pesel { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Blood BloodType { get; set; }

        public bool IsActive { get; set; }
    }
}
