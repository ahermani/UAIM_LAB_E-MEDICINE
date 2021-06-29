namespace Doctors.Infrastructure
{
    using Dapper;
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using ExaminationRooms.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Zsut.Patterns.CSharp;

    public class DoctorRepository : IDoctorRepository
    {
        private static List<Doctor> doctors = new List<Doctor>
        {
            new Doctor(1, "Jan", "Kowalski", "12345678911", PersonGender.Male, 8200, new List<Speciality>{ new Speciality(1, "Cardiologist", 3)}),
            new Doctor(2, "Janina", "Nowak", "12345678911", PersonGender.Female, 8000, new List<Speciality>{new Speciality(2, "Dentist", 1),new Speciality(3, "Laryngologist", 6)}),
            new Doctor(3, "Kamil", "Laszuk", "12665678911", PersonGender.Male, 9890, new List<Speciality>{new Speciality(4, "Dentist", 1),new Speciality(5, "Neurologist", 4),new Speciality(6, "Pediatrist", 2)}),
            new Doctor(4, "Albert", "Kral", "12665348911", PersonGender.Male, 9200, new List<Speciality>{new Speciality(7, "Urologist", 5),new Speciality(8, "Dermatologist", 7),new Speciality(9, "Pediatrist", 2)}),
            new Doctor(5, "Wanda", "Chalicka", "12665347711", PersonGender.Female, 9500, new List<Speciality>{new Speciality(9, "Dentist", 1),new Speciality(10, "Dermatologist", 7)}),
            new Doctor(6, "Marian", "Bam", "12665311911", PersonGender.Male, 7000, new List<Speciality>{new Speciality(11, "Urologist", 5),new Speciality(12, "Neurologist", 4)}),
            new Doctor(7, "Konrad", "Wimek", "22665311911", PersonGender.Male, 7000, new List<Speciality>{new Speciality(13, "Psychiatrist", 8)}),
            new Doctor(8, "Anna", "Jarmin", "12665341911", PersonGender.Female, 8000, new List<Speciality>{new Speciality(14, "Laryngologist", 6),new Speciality(15, "Neurologist", 4)}),
            new Doctor(9, "Anna", "Astra", "12665561911", PersonGender.Female, 8600, new List<Speciality>{new Speciality(16, "Dermatologist", 7),new Speciality(17, "Psychiatrist", 8)}),
            new Doctor(10, "Jakub", "Wolkowski", "00665561911", PersonGender.Male, 9600, new List<Speciality>{new Speciality(18, "Pediatrist", 2),new Speciality(19, "Dermatologist", 7),new Speciality(20, "Neurologist", 4)})};
        public DoctorRepository()
        {
        }

        public void AddDoctor(Doctor doctor)
        {
             doctors.Add(doctor);
        }


        public IEnumerable<Doctor> GetAll()
        {
            return doctors;
        }

        public IEnumerable<Doctor> GetBySpecialityNumber(int specialityNumber)
        {
            return doctors?.Where(ld => ld.Specializations.Any(s => s.Number == specialityNumber));
        }
    }
}
