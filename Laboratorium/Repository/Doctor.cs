namespace Zsut.Patterns.CSharp
{
    using System;

    public class Doctor : Person
    {
        #region Properties and Fields

        public string Speciality { get; set; }
        
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

        public Doctor(string name, string surname, string pesel, PersonGender gender, double wage, string speciality) : base(name, surname, pesel, gender)
        {
            this.Wage = wage;
            this.Speciality = speciality;
        }

        #endregion

        #region Methods

        public override string GetDescription()
        {
            return String.Format("{2}\nWage: {0}\nSpeciality: {1}\n", Wage, Speciality, base.GetDescription());
        }

        #endregion
    }
}
