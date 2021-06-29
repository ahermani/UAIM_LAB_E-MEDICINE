namespace ExaminationRooms.Web.Application.Commands
{
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Zsut.Patterns.CSharp;

    //"handler" komendy tworzenia gabinetu
    public class DoctorsCommandsHandler : ICommandHandler<AddDoctorCommand>
    {
        private readonly IDoctorRepository doctorsRepository;

        public DoctorsCommandsHandler(IDoctorRepository doctorsRepository)
        {
            this.doctorsRepository = doctorsRepository;
        }

        public void Handle(AddDoctorCommand command)
        {
            var specializations = new List<Speciality>();

            foreach (var number in command.Specializations)
                specializations.Add(new Speciality(0, "speciality", number));
            PersonGender gender = command.Gender == "Male" ? PersonGender.Male : PersonGender.Female;
            doctorsRepository.AddDoctor(new Doctor(0, command.Name, command.Surname, command.Pesel, gender, command.Wage, specializations));
        }
    }
}
