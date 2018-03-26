using ChatBot.Clients.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChatBot.Clients.Core.Converters
{
    public class TypeToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int parameterType = int.Parse(parameter.ToString());
            Xamarin.Forms.Color background = Color.Silver;
            UserMessage user = (UserMessage)value;
            var localUser = AppSettings.User.UserName;
            if (user.Name == localUser)
            {
                background = Color.FromHex("#0078D7");
                if (parameterType == 0)
                    background = Color.FromHex("#ECEFF1");
            }
            else
            {
                background = Color.FromHex("#ECEFF1");
                if (parameterType == 0)
                    background = Color.FromHex("#0078D7");
            }

            return background;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
