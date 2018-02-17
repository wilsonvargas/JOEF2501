using ChatBot.Clients.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatBot.Clients.Core.Converters
{
    public class TypeToColumnConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int column = 0;
            var user = (User)value;
            var id = AppSettings.User.Id;
            if (user.Id != id)
            {
                column = 0;
            }
            else
            {
                column = 1;
            }
            return column;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
