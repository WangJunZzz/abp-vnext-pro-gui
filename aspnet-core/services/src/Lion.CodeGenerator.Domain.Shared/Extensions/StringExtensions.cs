using System.Collections.Generic;
using System.Linq;


// ReSharper disable once CheckNamespace
namespace System
{
    public static class StringExtensions
    {
        public static string QueryDefaultSeparator = " ,\r\n;；，";
        public static List<string> ToSplitList(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return null;
            }
       
            var splits = value.Split(QueryDefaultSeparator.ToCharArray(),
                StringSplitOptions.RemoveEmptyEntries).ToList();

            if (splits.Count == 0)
            {
                return null;
            }

            return splits;
        }

        public static string ToSqlStartsWith(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return null;
            }

            return $"{value}%";
        }
        
        public static string ToSqlEndsWith(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return null;
            }

            return $"%{value}";
        }
        
        public static string ToSqlContains(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return null;
            }

            return $"%{value.Trim()}%";
        }

        public static string ToLocalizationNameSpace(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return value;
            }
            return value.Replace("DomainException", string.Empty);
        }

        public static string ToLocalizationNameSpace(this string code,string className)
        {
            var nameSpace = className.ToLocalizationNameSpace();
            return $"{nameSpace}.{code}";
        }
    }
}