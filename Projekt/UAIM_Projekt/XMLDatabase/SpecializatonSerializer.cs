using System;

namespace XMLDatabase
{
    
    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    using ModelClassLibrary;

    public class SpecializatonSerializer : ISerializer<Specialization>
    {

        private readonly XmlSerializer _xmlSerializer;

        public SpecializatonSerializer()
        {
            _xmlSerializer = new XmlSerializer(typeof(Specialization[]));
        }

        public static IEnumerable<Specialization> Make()
        {
            return new[]
            {
                new Specialization(0, "General", "Allows general checks on patients"),
                new Specialization(1, "Psychiatrist", "Allows psychotherapy"),
                new Specialization(2, "Dentist", "Allows dental treatments"),
                new Specialization(3, "Laryngologist", "Allows ENT procedures"),
                new Specialization(4, "Dietitian", "Allows diet selection"),
                new Specialization(5, "Cardiologist", "Allows cardiology diagnostics and treatments"),
                new Specialization(6, "Orthopaedist", "Allows diagnosis and treatment of bone diseases")
            };
        }

        public IEnumerable<Specialization> Deserialize()
        {
            try
            {
                using Stream stream = File.Open(Constants.SPECIALIZATIONSXMLDB, FileMode.Open);
                return (Specialization[]) _xmlSerializer.Deserialize(stream);
            }
            catch (FileNotFoundException e)
            {
                return Array.Empty<Specialization>();
            }
        }

        public void SerializeDemo()
        {
            using Stream stream = File.Open(Constants.SPECIALIZATIONSXMLDB, FileMode.Create);
            _xmlSerializer.Serialize(stream, Make());
            stream.Flush();
        }

        public void Serialize(List<Specialization> obj)
        {
            using Stream stream = File.Open(Constants.SPECIALIZATIONSXMLDB, FileMode.Create);
            _xmlSerializer.Serialize(stream, obj);
            stream.Flush();
        }
    }
}