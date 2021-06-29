using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XMLDatabase
{
    
    using ModelClassLibrary;
    
    public class PatientSerializer : ISerializer<Patient>
    {

        private readonly XmlSerializer _xmlSerializer;

        public PatientSerializer()
        {
            
            _xmlSerializer = new XmlSerializer(typeof(Patient[]));
        }

        public static IEnumerable<Patient> Make()
        {
            return new[]
            {
               
                new Patient(new Guid("65dff599-f82c-45c2-8496-d64c74bfaba1"), "Jan", "Kowalski", new DateTime(1980, 3, 1, 7, 0, 0), Gender.Male, "123456789", "kowalski.jan@gmail.com","00000000000", new DateTime(1980, 3, 1, 7, 0, 0), Blood.ABMinus, true),
                new Patient(new Guid("94da29c5-88ec-418e-9029-f1e2653cd751"), "Janina", "Nowak", new DateTime(1978, 4, 2, 10, 0, 0), Gender.Female, "123456780", "nowak.janina@wp.pl","00000000001", new DateTime(1978, 4, 2, 10, 0, 0), Blood.ABPlus, true)
            };
        }

        public IEnumerable<Patient> Deserialize()
        {
            try
            {
                using Stream stream = File.Open(Constants.PATIENTSXMLDB, FileMode.Open);
                return (Patient[]) _xmlSerializer.Deserialize(stream);
            }
            catch (FileNotFoundException e)
            {
                return Array.Empty<Patient>();
            }
        }

        public void SerializeDemo()
        {
            using Stream stream = File.Open(Constants.PATIENTSXMLDB, FileMode.Create);
            _xmlSerializer.Serialize(stream, Make());
            stream.Flush();
        }

        public void Serialize(List<Patient> obj)
        {
            using Stream stream = File.Open(Constants.PATIENTSXMLDB, FileMode.Create);
            _xmlSerializer.Serialize(stream, obj.ToArray());
            stream.Flush();
        }
    }
}