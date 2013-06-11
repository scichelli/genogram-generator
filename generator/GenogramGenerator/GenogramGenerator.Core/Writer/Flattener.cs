using System.Collections.Generic;
using System.Linq;

namespace GenogramGenerator.Core.Writer
{
    public class Flattener
    {
        private readonly Family _family;

        public Flattener(Family family)
        {
            _family = family;
        }

        public IEnumerable<PersonDto> Members()
        {
            return _family.Members().Select(m => new PersonDto(m));
        }

        public IEnumerable<RelationshipDto> Relationships()
        {
            return _family.Relationships.Select(r => new RelationshipDto(r));
        }
    }
}