using System;

namespace GenogramGenerator.Core
{
    public class Person
    {
        public Guid Id { get; private set; }
        public Family Family { get; set; }
        public string Name { get; set; }
        public Year BirthYear { get; set; }
        public Year? DeathYear { get; set; }
        public virtual Sex Sex { get; set; }

        public Relationship Is { get { return Family.Add(this); } }

        public float XPosition { get; set; }
        public int Generation { get; set; }
        public int DistanceToPrimaryLineage { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Name;
        }

        public int? Age()
        {
            return BirthYear.Age(DeathYear ?? new Year(DateTime.Now));
        }
    }

    public class Man : Person
    {
        public override Sex Sex
        {
            get
            {
                return Sex.M;
            }
        }
    }

    public class Woman : Person
    {
        public override Sex Sex
        {
            get
            {
                return Sex.F;
            }
        }
    }

    public enum Sex
    {
        F,
        M
    }
}