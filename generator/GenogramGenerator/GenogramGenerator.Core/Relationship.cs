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

        public void TheParentOf(Person person)
        {
            Set(person, RelationshipType.Parent);
        }

        public void TheChildOf(Person parent1, Person parent2)
        {
            var child = A;
            A = parent1;
            Set(child, RelationshipType.Parent);
            parent2.Is.TheParentOf(child);
        }

        public void MarriedTo(Person person)
        {
            Set(person, RelationshipType.Spouse);
        }

        public void DivorcedFrom(Person person)
        {
            Set(person, RelationshipType.Divorced);
        }

        public void TheRomanticPartnerOf(Person person)
        {
            Set(person, RelationshipType.Romance);
        }

        private void Set(Person b, RelationshipType type)
        {
            B = b;
            Type = type;
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