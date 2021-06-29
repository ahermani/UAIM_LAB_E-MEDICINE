using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientAppMicroservice.Dtos
{
    public class TreatmentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public float Price { get; set; }
        
        public uint Length { get; set; }

        public int[] RequiredSpecializations { get; set; }
    }
}
