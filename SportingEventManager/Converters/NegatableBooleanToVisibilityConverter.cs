using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SportingEventManager.Converters
{
    class NegatableBooleanToVisibilityConverter : IValueConverter
    {
        public NegatableBooleanToVisibilityConverter()
        {
            FalseVisibility = Visibility.Collapsed;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo ci)
        {
            object returnVal;
            bool bVal;
            bool result = bool.TryParse(value.ToString(), out bVal);

            if (!result) { returnVal = value; }
            else if (bVal && !Negate) { returnVal = Visibility.Visible; }
            else if (bVal && Negate) { returnVal = FalseVisibility; }
            else if (!bVal && Negate) { returnVal = Visibility.Visible; }
            else if (!bVal && !Negate) { returnVal = FalseVisibility; }
            else { returnVal = Visibility.Visible; }

            return returnVal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo ci)
        {
            throw new NotImplementedException();
        }

        public bool Negate { get; set; }
        public Visibility FalseVisibility { get; set; }
    }
}
