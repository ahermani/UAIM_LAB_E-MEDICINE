namespace ZsutPw.Patterns.WindowsApplication.Model
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ExaminationRoomDto
    {
        public string Number { get; set; }
        public IEnumerable<int> Certifications { get; set; }
    }
}
