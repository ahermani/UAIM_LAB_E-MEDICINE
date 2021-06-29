namespace ZsutPw.Patterns.WindowsApplication.Model
{
    using ModelClassLibrary;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
