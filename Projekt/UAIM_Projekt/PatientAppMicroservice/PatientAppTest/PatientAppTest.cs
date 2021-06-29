using ExaminationRoomsSelector.Web.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;
using PatientAppMicroservice.Application.Queries;
using PatientAppMicroservice.DataServiceClients;
using System;
using System.Threading.Tasks;

namespace PatientAppTest
{
    [TestClass]
    public class PatientAppTest
    {
        private static IPatientsServiceClient _patientsService;
        private static IDoctorsServiceClient _doctorsService;

        [AssemblyInitialize]
        public static void InitDependencyInjection(TestContext context)
        {
            var services = new ServiceCollection();
            services.AddControllers();
            services.AddHttpClient();
            services.AddTransient<IPatientsServiceClient, PatientsServiceClientTest>();
            services.AddTransient<IDoctorsServiceClient, DoctorsServiceClientTest>();
            var serviceProvider = services.BuildServiceProvider();

            _patientsService = serviceProvider.GetService<IPatientsServiceClient>();
            _doctorsService = serviceProvider.GetService<IDoctorsServiceClient>();
        }

        [TestMethod]
        public async Task GetPatientByIdTest()
        {
            Guid testGuid = new Guid("65dff599-f82c-45c2-8496-d64c74bfaba1");
            Patient resultPatient = await _patientsService.GetPatientByIdAsync(testGuid);
            Assert.AreEqual(testGuid, resultPatient.Id);
        }

        [TestMethod]
        public async Task GetDoctorByIdTest()
        {
            Guid testGuid = new Guid("a263446a-1eed-490c-af70-de5391370e67");
            Doctor resultDoctor = await _doctorsService.GetDoctorByIdAsync(testGuid);
            Assert.AreEqual(testGuid, resultDoctor.Id);
        }
    }
}
