using System;

namespace FitoGraph.Api.Infrastructure
{
    public static class SafeConvert
    {
        public static DateTime toDateTime(this object dateTime, DateTime defValue)
        {
            DateTime d = DateTime.MinValue;
            if (dateTime == null)
                return d;

            if (DateTime.TryParse(dateTime.ToString(), out d))
                return d;
            else
                return defValue;
        }
        public static int toInt(this object strValue, int defValue)
        {
            int d = defValue;
            if (strValue == null)
                return d;
         
            if (int.TryParse(strValue.ToString().FixPersianNumbers(), out d))
                return d;
            else
                return defValue;
        }
        public static long toLong(this object strValue, long defValue)
        {
            long d = defValue;
            if (strValue == null)
                return d;

            if (long.TryParse(strValue.ToString().FixPersianNumbers(), out d))
                return d;
            else
                return defValue;
        }
        public static decimal toDecimal(this object strValue, decimal defValue)
        {
            decimal d = defValue;
            if (strValue == null)
                return d;

            if (decimal.TryParse(strValue.ToString().FixPersianNumbers(), out d))
                return d;
            else
                return defValue;
        }
        public static double toDouble(this object strValue, double defValue)
        {
            double d = defValue;
            if (strValue == null)
                return d;

            if (double.TryParse(strValue.ToString().FixPersianNumbers(), out d))
                return d;
            else
                return defValue;
        }

    }

}