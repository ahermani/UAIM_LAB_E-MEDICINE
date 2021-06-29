using Newtonsoft.Json;
using System;

namespace ZsutPw.Patterns.WindowsApplication.Model
{
    public class Pair
    {
        public DoctorDto Doctor { get; set; }
        public ExaminationRoomDto Room { get; set; }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Pair p = (Pair)obj;
                return (Doctor == p.Doctor) && (Room == p.Room);
            }
        }

    }
}

