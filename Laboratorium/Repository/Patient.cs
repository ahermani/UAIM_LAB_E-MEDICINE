namespace Zsut.Patterns.CSharp
{
    using System;
    using System.Diagnostics;
    public class Patient : Person
    {
        #region Properties and Fields
        public int ReservationNumber { get; private set; }

        #endregion

        #region Constructors
        public Patient(string name, string surname, string pesel, PersonGender gender, int reservationNumber) : base(name, surname, pesel, gender)
        {
            Debug.Assert(condition: reservationNumber > 0);

            this.ReservationNumber = reservationNumber;
        }

        #endregion

        #region Methods
        public override string GetDescription()
        {
            return String.Format("{1}\nReservation Number: {0}\n", ReservationNumber, base.GetDescription());
        }

        #endregion
    }
}
