using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XMLDatabase
{
    
    using ModelClassLibrary;
    
    public class DoctorSerializer : ISerializer<Doctor>
    {

        private readonly XmlSerializer _xmlSerializer;

        public DoctorSerializer()
        {
            
            _xmlSerializer = new XmlSerializer(typeof(Doctor[]));
        }

        public static IEnumerable<Doctor> Make()
        {
            return new[]
            {

                new Doctor(new Guid("65dff599-f82c-45c2-8496-d64c74bfaba1"), "Jan", "Kowalski", new DateTime(1980, 3, 1, 7, 0, 0), Gender.Male, "123456789", "kowalski.jan@gmail.com", new List<int>{0,1,3}, "302"),
                new Doctor(new Guid("94da29c5-88ec-418e-9029-f1e2653cd751"), "Janina", "Nowak", new DateTime(1978, 4, 2, 10, 0, 0), Gender.Female, "123456780", "nowak.janina@wp.pl", new List<int>{2,5}, "408")
            };
        }

        public IEnumerable<Doctor> Deserialize()
        {
            try
            {
                using Stream stream = File.Open(Constants.DOCTORSXMLDB, FileMode.Open);
                return (Doctor[]) _xmlSerializer.Deserialize(stream);
            }
            catch (FileNotFoundException e)
            {
                return Array.Empty<Doctor>();
            }
        }

        public void SerializeDemo()
        {
            using Stream stream = File.Open(Constants.DOCTORSXMLDB, FileMode.Create);
            _xmlSerializer.Serialize(stream, Make());
            stream.Flush();
        }

        public void Serialize(List<Doctor> obj)
        {
            using Stream stream = File.Open(Constants.DOCTORSXMLDB, FileMode.Create);
            _xmlSerializer.Serialize(stream, obj.ToArray());
            stream.Flush();
        }
    }
}