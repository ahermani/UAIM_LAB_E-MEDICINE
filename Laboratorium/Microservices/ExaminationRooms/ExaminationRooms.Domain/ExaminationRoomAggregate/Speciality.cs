using ExaminationRooms.Domain.SeedWork;
namespace ExaminationRooms.Domain.ExaminationRoomAggregate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Speciality : Entity
    {
        public Speciality(int id, string description, int number) : base(id)
        {
            Description = description;
            Number = number;
        }

        public string Description { get; set; }

        public int Number { get; set; }


    }
}
