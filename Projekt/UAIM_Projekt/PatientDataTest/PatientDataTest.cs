using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;
using PatientDataMicroservice.DAO;
using PatientDataMicroservice.DTO;
using PatientsDataMicroservice.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XMLDatabase;

namespace PatientDataTest
{
    [TestClass]
    public class PatientDataTest
    {
        private readonly PatientSerializer _serializer = new();

        [TestInitialize, TestCleanup]
        public void RestoreDatabase()
        {
            _serializer.Serialize(PatientSerializer.Make().ToList());
        }

        [TestMethod]
        public async Task AddPatientTest()
        {
            PatientDTO patient = new PatientDTO();
            patient.Name = "Anna";
            patient.Surname = "Jarocka";
            patient.Birthday = DateTime.Now;
            patient.Gender = Gender.Female;
            patient.PhoneNumber = "123123123";
            patient.Email = "jarocka@gmail.com";
            patient.Pesel = "123123123";
            patient.RegistrationDate = DateTime.Now;
            patient.BloodType = Blood.ABMinus;
            patient.IsActive = true;
            
            var dao = new DaoPatientXMLAsync();
            Patient addedPatient = await dao.AppendAsync(patient);
            var Patients = new List<Patient>(await dao.GetAllAsync());

            Assert.IsNotNull(Patients.Find(t => t.Surname == "Jarocka"));
        }

        [TestMethod]
        public async Task GetByIdTest()
        {
            Guid id = new Guid("94da29c5-88ec-418e-9029-f1e2653cd751");
            var dao = new DaoPatientXMLAsync();
            List < Patient > patients = (await dao.GetAllAsync()).ToList();
            Patient patient = (await dao.GetByIdAsync(id));
            Guid responseId = patient.Id;
            Assert.AreEqual(id, responseId, "Patient Id should be {0}, not {1}", id, responseId);
            

        }
    }
}
