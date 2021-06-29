using System;

namespace ExaminationRoomsSelector.Web.Application.Queries
{
    public class Pair
    {
        public Pair(Dtos.DoctorDto doctor, Dtos.ExaminationRoomDto room)
        {
            this.doctor = doctor;
            this.room = room;
        }

        public Dtos.DoctorDto doctor { get; set; }
        public Dtos.ExaminationRoomDto room { get; set; }

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
                return (doctor == p.doctor) && (room == p.room);
            }
        }

    }
}

