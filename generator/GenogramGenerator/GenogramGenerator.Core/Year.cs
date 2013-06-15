using System;
using System.Globalization;

namespace GenogramGenerator.Core
{
    public struct Year
    {
        private readonly DateTime _year;

        public Year(DateTime year)
        {
            _year = year;
        }

        public Year(int year) : this(new DateTime(year, 1, 1))
        {
        }

        public int? Age(DateTime asOfDate)
        {
            return _year == DateTime.MinValue ? (int?) null : asOfDate.Year - _year.Year;
        }

        public int? Age(Year asOfYear)
        {
            return Age(asOfYear._year);
        }

        public override string ToString()
        {
            return _year == DateTime.MinValue ? string.Empty : _year.Year.ToString(CultureInfo.InvariantCulture);
        }
    }
}