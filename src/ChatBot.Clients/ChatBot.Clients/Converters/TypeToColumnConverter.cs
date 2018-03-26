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
            UserMessage user = (UserMessage)value;
            var localUser = AppSettings.User.UserName;
            int column = 0;
            if (user.Name != localUser)
            {
                column = 0;
            }
            else
            {
                column = 2;
            }
            return column;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
