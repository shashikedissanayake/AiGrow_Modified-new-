using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.UI.WebControls;

namespace AiGrow
{
    [System.Diagnostics.DebuggerStepThrough()]
    public static class ApplicationUtilities
    {
        public static bool IsNotEmpty(this TextBox control)
        {
            return !string.IsNullOrEmpty(control.Text);
        }

        public static bool IsEmpty(this TextBox control)
        {
            return string.IsNullOrEmpty(control.Text);
        }

        public static bool IsEmpty(this string str)
        {
            return str == null ? string.IsNullOrEmpty(str) : string.IsNullOrEmpty(str.Trim());
        }

        public static bool IsNotEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static double ToDouble(this string value)
        {
            return Convert.ToDouble(value.Trim());
        }

        public static decimal ToDecimal(this string value)
        {
            return string.IsNullOrEmpty(value) ? 0.0m : Convert.ToDecimal(value.Trim());
        }

        public static string DateFromString(this string value)
        {
            return value.IsEmpty() ? null : Convert.ToDateTime(value).ToShortDateString();
        }

        public static int? ToIntNullable(this string value)
        {
            return (value.Trim().IsEmpty()) ? (int?)null : (value.Trim().All(Char.IsDigit) ? Convert.ToInt32(value.Trim()) : (int?)null);
        }

        public static string NullIfEmpty(this string value)
        {
            return string.IsNullOrEmpty(value.Trim()) ? null : value.Trim();
        }

        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);

                            object a = Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType);

                            propertyInfo.SetValue(obj, a, null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static System.Drawing.Image byteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }

    }
}
