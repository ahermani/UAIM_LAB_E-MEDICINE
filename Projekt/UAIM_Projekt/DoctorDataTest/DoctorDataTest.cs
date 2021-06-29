using DoctorsDataMicroservice.DAO;
using DoctorsDataMicroservice.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XMLDatabase;

namespace DoctorDataTest
{
    [TestClass]
    public class DoctorDataTest
    {
        private readonly DoctorSerializer _serializer = new();

        [TestInitialize, TestCleanup]
        public void RestoreDatabase()
        {
            _serializer.Serialize(DoctorSerializer.Make().ToList());
        }

        [TestMethod]
        public async Task AddDoctorTest()
        {
            DoctorDTO Doctor = new DoctorDTO();
            Doctor.Name = "Anna";
            Doctor.Surname = "Jarocka";
            Doctor.Birthday = DateTime.Now;
            Doctor.Gender = Gender.Female;
            Doctor.PhoneNumber = "123123123";
            Doctor.Email = "jarocka@gmail.com";
            Doctor.Specialization = new List<int>() {1, 2 };
            Doctor.Room = "203";

            var dao = new DaoDoctorXMLAsync();
            Doctor addedDoctor = await dao.AppendAsync(Doctor);
            var Doctors = new List<Doctor>(await dao.GetAllAsync());

            Assert.IsNotNull(Doctors.Find(t => t.Surname == "Jarocka"));
        }

        [TestMethod]
        public async Task GetByIdTest()
        {
            Guid id = new Guid("65dff599-f82c-45c2-8496-d64c74bfaba1");
            var dao = new DaoDoctorXMLAsync();
            List<Doctor> Doctors = (await dao.GetAllAsync()).ToList();
            Doctor Doctor = (await dao.GetByIdAsync(id));
            Guid responseId = Doctor.Id;
            Assert.AreEqual(id, responseId, "Doctor Id should be {0}, not {1}", id, responseId);


        }
    }
}
