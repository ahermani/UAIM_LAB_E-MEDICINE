
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZsutPw.Patterns.WindowsApplication.Model;

namespace UWPTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetPatientById()
        {
            INetwork networkClient = NetworkClientFactory.GetNetworkClient();
            String id = "2a1f0ec5-7c79-4718-9beb-52ee28767a00";
            PatientDto patient = networkClient.GetPatient(id);
            String responseId = patient.Id.ToString();
            Assert.AreEqual(id, responseId);

        }

         
    }
}
