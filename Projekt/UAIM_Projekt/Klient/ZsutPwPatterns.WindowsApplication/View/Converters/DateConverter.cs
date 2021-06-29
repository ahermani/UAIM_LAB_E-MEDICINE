using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ZsutPw.Patterns.WindowsApplication.View
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            //DateTime? date = value==null ? DateTime.Now : (DateTime?)value;
            DateTime? date = (DateTime?)value;
            return date?.ToString("MM-dd-yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            if (value == null)
                return null;
            string strValue = value as string;
            DateTime resultDateTime;
            //return DateTime.Parse(strValue);
            if (DateTime.TryParse(strValue, out resultDateTime))
            {
                return resultDateTime;
            }
            return DependencyProperty.UnsetValue;
        }
    }
}
