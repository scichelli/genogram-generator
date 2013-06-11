using System.Collections.Generic;
using System.Linq;

namespace GenogramGenerator.Core
{
    public class Family
    {
        private readonly List<Relationship> _relationships = new List<Relationship>();

        public IEnumerable<Relationship> Relationships { get { return _relationships; } } 

        public IEnumerable<Person> Members()
        {
            return _relationships.Select(r => r.A).Union(_relationships.Select(r => r.B));
        }

        public IEnumerable<Person> SiblingsOf(Person person)
        {
            var parents = ParentsOf(person);
            return ChildrenOf(parents).Where(s => s != person);
        }

        public IEnumerable<Person> ParentsOf(Person person)
        {
            return _relationships.Where(r => r.B == person && r.Type == RelationshipType.Parent).Select(r => r.A);
        }

        public IEnumerable<Person> ChildrenOf(IEnumerable<Person> parents)
        {
            if (!parents.Any())
                return Enumerable.Empty<Person>();

            return parents.Skip(1)
                .Aggregate(ChildrenOf(parents.First()),
                           (current, parent) => current.Intersect(ChildrenOf(parent)));
        }

        public IEnumerable<Person> ChildrenOf(Person parent)
        {
            return _relationships.Where(r => r.Type == RelationshipType.Parent && r.A == parent).Select(r => r.B);
        }

        public Person Add(string name)
        {
            return new Person { Name = name, Family = this };
        }

        public Relationship Add(Person person)
        {
            var relationship = new Relationship { A = person };
            _relationships.Add(relationship);
            return relationship;
        }
    }
}
