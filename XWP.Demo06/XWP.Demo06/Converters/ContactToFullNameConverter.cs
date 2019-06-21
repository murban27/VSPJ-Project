using System;
using System.Globalization;
using Xamarin.Forms;
using XWP.Demo06.Model;

namespace XWP.Demo06.Converters
{
    public class ContactToFullNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var contact = value as Contact;
            if (contact == null)
            {
                return null;
            }

            return $"{contact.FirstName} {contact.LastName}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
