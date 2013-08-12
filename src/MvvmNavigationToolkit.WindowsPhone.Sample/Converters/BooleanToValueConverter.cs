using System;
using System.Globalization;
using System.Windows.Data;

namespace MvvmNavigationToolkit.WindowsPhone.Sample.Converters
{
    public class BooleanToValueConverter : IValueConverter
    {
        public object ValueForTrue { get; set; }

        public object ValueForFalse { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var b = (Boolean?)value;
            return (b.GetValueOrDefault(false)) ? this.ValueForTrue : this.ValueForFalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
