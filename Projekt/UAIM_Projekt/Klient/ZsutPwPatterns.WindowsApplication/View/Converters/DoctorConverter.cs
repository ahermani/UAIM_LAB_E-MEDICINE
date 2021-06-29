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

  public class DoctorConverter : IValueConverter
  {
    public object Convert( object value, Type targetType, object parameter, string language )
    {
      DoctorDto doctor = (DoctorDto)value;
            if (doctor == null)
                return "";
      return String.Format( "Doctor: {0} {1}, specializations: {2}", doctor.Name, doctor.Surname, string.Join(", ", doctor.Specialization));
    }

    public object ConvertBack( object value, Type targetType, object parameter, string language )
    {
      throw new NotImplementedException( );
    }
  }
}
