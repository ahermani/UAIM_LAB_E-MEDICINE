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

    public class GuidConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return "";
            Guid id = (Guid)value;
            return id.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string strValue = value as string;
            return new Guid(strValue);
        }
    }
}
