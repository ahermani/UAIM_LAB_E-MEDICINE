using System.Xml.Serialization;

namespace ModelClassLibrary
{
    
    using System;
    using System.Collections.Generic;
    
    public class Treatment
    {
        public Treatment(Guid id, string name, float price, TimeSpan length, int[] requiredSpecializations)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Length = length;
            RequiredSpecializations = requiredSpecializations ??
                                      throw new ArgumentNullException(nameof(requiredSpecializations));
        }
        
        public Treatment() {}

        
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public float Price { get; set; }
        
        public TimeSpan Length { get; set; }
        
        public int[] RequiredSpecializations { get; set; }
    }
}