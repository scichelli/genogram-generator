using System;
using GenogramGenerator.Core;
using Should;

namespace GenogramGenerator.Tests
{
    public class PersonTests
    {
        readonly Person _person = new Person();

        public void UninitializedBirthYearShouldNotThrow()
        {
            _person.BirthYear.ToString().ShouldEqual(string.Empty);
        }

        public void SetBirthYearWithADate()
        {
            _person.BirthYear = new Year(new DateTime(1941, 4, 28));
            _person.BirthYear.ToString().ShouldEqual("1941");
        }

        public void SetBirthYearWithAYear()
        {
            _person.BirthYear = new Year(2001);
            _person.BirthYear.ToString().ShouldEqual("2001");
        }

        public void FindAge()
        {
            _person.BirthYear = new Year(1985);
            _person.BirthYear.Age(new DateTime(1995, 8, 25)).ShouldEqual(10);
        }

        public void UninitializedAgeShouldBeNull()
        {
            _person.BirthYear.Age(DateTime.Now).ShouldBeNull();
        }
    }
}