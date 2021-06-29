//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Patterns.WindowsApplication.View
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Windows.UI.Xaml.Data;

    using ZsutPw.Patterns.WindowsApplication.Model;

    public class DoctorDetailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DoctorDto doctor = (DoctorDto)value;
            if (doctor == null)
                return "";
            return String.Format("\nName: {0}\nSurname: {1}\nBirthday: {2}\nGender: {3}\nPhone number: {4}\nEmail: {5}\nSpecializations: {6}\nRoom: {7}\n", doctor.Name, doctor.Surname, doctor.Birthday, doctor.Gender, doctor.PhoneNumber, doctor.Email, string.Join(", ", doctor.Specialization), doctor.Room);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
