namespace ZsutPw.Patterns.WindowsApplication.View
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Windows.UI.Xaml.Data;

    using ZsutPw.Patterns.WindowsApplication.Model;
    class PatientDetailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
             PatientDto patient = (PatientDto)value;
             if (patient == null)
                 return "";
             return String.Format("\nName: {0}\nSurname: {1}\nBirthday: {2}\nGender: {3}\nPhone number: {4}\nEmail: {5}\nPESEL: {6}\nRegistration Date: {7}\nBlood type: {8}\nActive: {9}\n", patient.Name, patient.Surname, patient.Birthday, patient.Gender, patient.PhoneNumber, patient.Email, patient.Pesel, patient.RegistrationDate, patient.BloodType, patient.IsActive);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
