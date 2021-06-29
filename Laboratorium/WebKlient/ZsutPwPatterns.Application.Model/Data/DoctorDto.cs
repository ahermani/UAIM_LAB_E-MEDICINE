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

    public class DoctorDto
    {
        public double Wage { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<string> Specializations { get; set; }

    }
}
