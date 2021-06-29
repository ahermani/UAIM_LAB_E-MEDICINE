namespace Zsut.Patterns.CSharp
{
    using System;
    using System.Linq;

    public abstract class Person
    {
        #region Properties and Fields

        public PersonGender Gender { get; set; }
        public int Id { get; protected set; }

        public string Name
        {
            get { return this.name; }

            internal set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or white space");
                }

                this.name = value;
            }
        }

        private string name;


        public string Pesel
        {
            get { return this.pesel; }

            internal set
            {
                if( !(value.All(char.IsDigit) && value.Length == 11))
                {
                    throw new ArgumentException("PESEL must have 11 digits");
                }

                this.pesel = value;
            }
        }

        private string pesel;


        public string Surname
        {
            get { return this.surname; }

            internal set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Surname cannot be null or white space");
                }

                this.surname = value;
            }
        }

        private string surname;

        #endregion

        #region Constructors

        public Person(int id, string name, string surname, string pesel, PersonGender gender)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Pesel = pesel;
            this.Gender = gender;
        }

        #endregion

        #region Methods

        public virtual string GetDescription()
        {
            return String.Format("{4}\nName: {0}\nSurname: {1}\nPESEL: {2}\nGender: {3}\n", this.Name, this.Surname, this.Pesel, this.Gender, this.GetType().Name);
        }

        #endregion
    }
}
