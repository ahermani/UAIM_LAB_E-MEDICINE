namespace ModelClassLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    public class Doctor : Person
    {
        public Doctor(Guid id, string name, string surname, DateTime birthday, Gender gender, string phoneNumber,
            string email, List<int> specialization, string room) : base(id, name, surname, birthday, gender,
            phoneNumber, email)
        {
            Specialization = specialization ?? throw new ArgumentNullException(nameof(specialization));
            Room = room ?? throw new ArgumentNullException(nameof(room));
        }
        
        public Doctor() {}
        
        
        public List<int> Specialization { get; set; }
        
        public string Room { get; set; }
    }
}