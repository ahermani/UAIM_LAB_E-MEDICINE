namespace Zsut.Patterns.CSharp
{
    using ExaminationRooms.Domain.ExaminationRoomAggregate;
    using System;
    using System.Collections.Generic;

    public class Doctor : Person
    {
        #region Properties and Fields

        public IList<Speciality> Specializations { get; set; } = new List<Speciality>();
        
        public double Wage
        {
            get { return this.wage; }

            internal set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Wage cannot be less or equal zero");
                }

                this.wage = value;
            }
        }

        private double wage;

        #endregion

        #region Constructors

        public Doctor(int id, string name, string surname, string pesel, PersonGender gender, double wage, IList<Speciality> specializations) : base(id, name, surname, pesel, gender)
        {
            this.Wage = wage;
            this.Specializations = specializations;
        }

        public Doctor(int id, string name, string surname, string pesel, PersonGender gender, decimal wage) : base(id, name, surname, pesel, gender)
        {
            this.Wage = (double) wage;
        }

        #endregion

        #region Methods

        public override string GetDescription()
        {
            return String.Format("{2}\nWage: {0}\nSpeciality: {1}\n", Wage, Specializations.ToString(), base.GetDescription());
        }

        public void AddSpecializations(IEnumerable<Speciality> specializations)
        {
            foreach (var specialization in specializations)
                Specializations.Add(specialization);
        }

        #endregion
    }
}
