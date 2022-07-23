using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Syncfusion.ListView.XForms;
using Xamarin.Forms;

namespace FarmLabDevice.Converters
{
    public class CustomConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object eventArgs = null;
            if (value is Syncfusion.ListView.XForms.ItemTappedEventArgs)
                eventArgs = value as Syncfusion.ListView.XForms.ItemTappedEventArgs;
            else if (value is ListViewLoadedEventArgs)
                eventArgs = parameter;
            else if (value is SwipingEventArgs)
                eventArgs = value as SwipingEventArgs;
            return eventArgs;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
