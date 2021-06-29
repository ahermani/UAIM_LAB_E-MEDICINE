using System.Xml.Serialization;

namespace ModelClassLibrary
{
    using System;
    
    public class Specialization
    {
        public Specialization(int id, string name, string description)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
        
        public Specialization() {}

        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}