
using MyExpenses.Utilities;
using System;
using System.Globalization;
using System.Windows;
using Windows.ApplicationModel.Resources;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace MyExpenses.Common
{
    public class BooleanToStringConverter : IValueConverter
    {
        /// <summary>
        /// To get the true of false value of object
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>True or false</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToBoolean(value) ? "True" : "False";
        }

        /// <summary>
        /// To convert object value into true or false
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>True or false</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToString(value) == "True" ? true : false;
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// To get visiblity or collapse
        /// </summary>
        /// <param name="value">object</param>
        /// <param name="targetType">Type</param>
        /// <param name="parameter">object</param>
        /// <param name="culture">System.Globalization.CultureInfo</param>
        /// <returns>visiblity or collapsed</returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Convert.ToBoolean(value) ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        /// To convert back to visiblity
        /// </summary>
        /// <param name="value">object</param>
        /// <param name="targetType">Type</param>
        /// <param name="parameter">object</param>
        /// <param name="culture">System.Globalization.CultureInfo</param>
        /// <returns>Convertback of visiblity </returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                return (Visibility)value == Visibility.Visible ? true : false;
            }
            catch { return false; }
        }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return System.Convert.ToBoolean(value) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class IntToVisibiltyConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {

            return value = System.Convert.ToInt32(value) <= 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

    }

   


  
    public class EmptyStringVisbilityCollapesedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return Visibility.Collapsed;
            else if (value.ToString() == "" )
                return Visibility.Collapsed;
            else
                return Visibility.Visible;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class ZeroToVisbilityCollapesedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is string && (System.Convert.ToString(value) == "0.000" || System.Convert.ToString(value) == "0.00"))
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
   
    public class ResourceStringConventer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ResourceLoader resourceLoader = new ResourceLoader();
            string text = resourceLoader.GetString((string)value);
            return text;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class LocalDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string ConvertDate = value.ToString();
            DateTime currentDate = System.Convert.ToDateTime(ConvertDate);
            string format = "hh:mm tt";
            ConvertDate = currentDate.ToString(format, CultureInfo.InvariantCulture);
            return ConvertDate;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    public class ArabictoLocalDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string ConvertDate = value.ToString();
            DateTime currentDate = System.Convert.ToDateTime(ConvertDate);
            if (parameter != null && parameter.ToString() == "FullDate")
            {
                ConvertDate = currentDate.ToString("hh:mm tt dd MMM yyyy", CultureInfo.InvariantCulture);
            }
            else if (parameter != null && parameter.ToString() == "Time")
            {
                ConvertDate = currentDate.ToString("hh:mm tt", CultureInfo.InvariantCulture);
            }
            else if (parameter != null && parameter.ToString() == "DayMonthYear")
            {
                ConvertDate = currentDate.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            }
            else
                ConvertDate = currentDate.ToString("D", CultureInfo.InvariantCulture);
            return ConvertDate;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
     public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                DateTime dt = DateTime.Now;

                string defaultformat = dt.ToString();
                int index=defaultformat.IndexOf(" ");
                defaultformat = defaultformat.Substring(0, index);
                
                string DDay, DMonth=string.Empty, DYear;
                if (defaultformat.Contains("/"))
                {
                    string[] defaultValues = defaultformat.Split('/');
                    DDay = defaultValues[1];
                    DMonth = defaultValues[0];
                    DYear = defaultValues[2];
                }
                else
                {
                    if (defaultformat.Contains("-"))
                    {
                        string[] defaultValues = defaultformat.Split('-');
                        DDay = defaultValues[1];
                        DMonth = defaultValues[0];
                        DYear = defaultValues[2];
                    }
                }


                ///Convert Class throws exception so can not convert to date time
                string TheCurrentDate = value.ToString();
                // DateTime cur = System.Convert.ToDateTime(TheCurrentDate, CultureInfo.InvariantCulture);
               
                string Day, Month, Year;
                if (defaultformat.Contains("/"))
                {
                    string[] Values = TheCurrentDate.Split('/');
                    if (DMonth == dt.Month.ToString())
                    {
                        Day = Values[1];
                        Month = Values[0];
                    }
                    else
                    {
                        Day = Values[0];
                        Month = Values[1];
                    }
                    Year = Values[2];
                }else
                {

                    string[] Values = TheCurrentDate.Split('-');
                    if (DMonth == dt.Month.ToString())
                    {
                        Day = Values[1];
                        Month = Values[0];
                    }
                    else
                    {
                        Day = Values[0];
                        Month = Values[1];
                    }
                    Year = Values[2];
                }

                string retvalue = string.Format("{0}/{1}", Month, Year);
                return retvalue;
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    public class DateEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                /////Convert Class throws exception so can not convert to date time
                //string TheCurrentDate = value.ToString();
                //// DateTime cur = System.Convert.ToDateTime(TheCurrentDate, CultureInfo.InvariantCulture);
                //string[] Values = TheCurrentDate.Split('/');
                //string Day, Month, Year;

                //Day = Values[1];
                //Month = Values[0];
                //Year = Values[2];

                string retvalue = string.Format("{0}", " ");
                return retvalue;
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
