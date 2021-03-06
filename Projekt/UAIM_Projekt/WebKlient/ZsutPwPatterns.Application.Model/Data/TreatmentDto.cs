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

    public class TreatmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }

        public uint Length { get; set; }

        public int[] RequiredSpecializations { get; set; }

    }
}
