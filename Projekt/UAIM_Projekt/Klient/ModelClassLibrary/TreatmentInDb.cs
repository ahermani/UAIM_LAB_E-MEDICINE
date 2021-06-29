namespace ModelClassLibrary.Treatments
{
    
    using System;
    
    public class TreatmentInDB : TreatmentBase
    {
        public TreatmentInDB(Guid id, string name, float price, uint length, int[] requiredSpecializations)
            : base(name, price, length, requiredSpecializations)
        {
            Id = id;
        }

        public TreatmentInDB(Guid id, TreatmentBase treatmentBase)
            : base(treatmentBase.Name, treatmentBase.Price, treatmentBase.Length, treatmentBase.RequiredSpecializations)
        {
            Id = id;
        }

        public TreatmentInDB(TreatmentBase treatmentBase)
            : base(treatmentBase.Name, treatmentBase.Price, treatmentBase.Length, treatmentBase.RequiredSpecializations)
        {
            Id = Guid.NewGuid();
        }
        
        public TreatmentInDB() : base()
        {
            
        }

        public Guid Id { get; set; }
    }
}