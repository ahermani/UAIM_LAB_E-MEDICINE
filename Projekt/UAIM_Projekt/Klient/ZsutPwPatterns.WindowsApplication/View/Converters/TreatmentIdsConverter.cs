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
    public class TreatmentIdsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            if (value == null)
                return "";
            List<Guid> treatmentIds = (List<Guid>)value;
            string[] stringIds = treatmentIds.Select((x => x.ToString())).ToArray();
            string resultIds = string.Join(", ", stringIds);
            return resultIds;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            string strValue = value as string;
            List<Guid> resultTreatmentIds = strValue.Trim().Split(',').Select(x => new Guid(x)).ToList();

            return resultTreatmentIds;
        }
    }
}
