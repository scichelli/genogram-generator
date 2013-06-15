using System;
using GenogramGenerator.Core;
using Should;

namespace GenogramGenerator.Tests
{
    public class YearTests
    {
        public void SetBirthYearWithADate()
        {
            var year = new Year(new DateTime(1941, 4, 28));
            year.ToString().ShouldEqual("1941");
        }

        public void SetBirthYearWithAYear()
        {
            var year = new Year(2001);
            year.ToString().ShouldEqual("2001");
        }

        public void FindAge()
        {
            var year = new Year(1985);
            year.Age(new DateTime(1995, 8, 25)).ShouldEqual(10);
        }

        public void UninitializedAgeShouldBeNull()
        {
            var year = new Year();
            year.Age(DateTime.Now).ShouldBeNull();
        }

        public void FindAgeFromAYear()
        {
            var year = new Year(1920);
            year.Age(new Year(1980)).ShouldEqual(60);
        }
    }
}