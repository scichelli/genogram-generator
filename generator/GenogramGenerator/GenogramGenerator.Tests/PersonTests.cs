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

        public void UninitializedDeathShouldBeNull()
        {
            _person.DeathYear.ShouldBeNull();
        }

        public void AgeIfLivingShouldCalculateFromNow()
        {
            _person.BirthYear = new Year(2010);
            _person.Age().ShouldBeGreaterThan(2);
        }

        public void AgeIfDeceasedShouldBeCalculatedFromDeathDate()
        {
            _person.BirthYear = new Year(1960);
            _person.DeathYear = new Year(2000);
            _person.Age().ShouldEqual(40);
        }
    }
}