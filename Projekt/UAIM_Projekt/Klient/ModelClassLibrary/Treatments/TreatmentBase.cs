using System;

namespace ModelClassLibrary.Treatments
{
    public class TreatmentBase
    {
        public TreatmentBase(string name, float price, uint length, int[] requiredSpecializations)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Price = price;
            Length = length;
            RequiredSpecializations = requiredSpecializations ??
                                      throw new ArgumentNullException(nameof(requiredSpecializations));
        }
        
        public TreatmentBase() {}

        public string Name { get; set; }
        
        public float Price { get; set; }
        
        public uint Length { get; set; }
        
        public int[] RequiredSpecializations { get; set; }
    }
}