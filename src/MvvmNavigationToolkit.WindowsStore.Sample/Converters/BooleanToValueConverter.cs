using System;
using Windows.UI.Xaml.Data;

namespace MvvmNavigationToolkit.WindowsStore.Sample.Converters
{
    public class BooleanToValueConverter : IValueConverter
    {
        public object ValueForTrue { get; set; }

        public object ValueForFalse { get; set; }

        public object Convert(object value, Type targetType, object parameter, string culture)
        {
            var b = (Boolean?)value;
            return (b.GetValueOrDefault(false)) ? this.ValueForTrue : this.ValueForFalse;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string culture)
        {
            throw new NotSupportedException();
        }
    }
}
