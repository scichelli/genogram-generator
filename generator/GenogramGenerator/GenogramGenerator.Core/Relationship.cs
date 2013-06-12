using System.Collections.Generic;

namespace GenogramGenerator.Core
{
    public class Relationship
    {
        public Person A { get; set; }
        public Person B { get; set; }
        public RelationshipType Type { get; set; }

        public IEnumerable<Person> Relatives
        {
            get
            {
                yield return A;
                yield return B;
            }
        }

        public Relationship TheParentOf(Person person)
        {
            return Set(person, RelationshipType.Parent);
        }

        public void TheChildOf(Person parent1, Person parent2)
        {
            var child = A;
            A = parent1;
            Set(child, RelationshipType.Parent);
            parent2.Is.TheParentOf(child);
        }

        public Relationship MarriedTo(Person person)
        {
            return Set(person, RelationshipType.Spouse);
        }

        public Relationship DivorcedFrom(Person person)
        {
            return Set(person, RelationshipType.Divorced);
        }

        public Relationship TheRomanticPartnerOf(Person person)
        {
            return Set(person, RelationshipType.Romance);
        }

        public void AndTheyAreTheParentsOf(params Person[] children)
        {
            new[]{A, B}.AreTheParentsOf(children);
        }

        private Relationship Set(Person b, RelationshipType type)
        {
            B = b;
            Type = type;
            return this;
        }
    }

    public enum RelationshipType
    {
        Parent,
        Spouse,
        Divorced,
        Romance
    }
}