using System;
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
            return RelationshipsByType(r => true);
        }

        public IEnumerable<RelationshipDto> Parents()
        {
            return RelationshipsByType(r => r.Type == RelationshipType.Parent);
        }

        public IEnumerable<RelationshipDto> Peers()
        {
            return RelationshipsByType(r =>
                                       r.Type.IsOneOf(RelationshipType.Spouse, RelationshipType.Romance,
                                                      RelationshipType.Divorced));
        }

        private IEnumerable<RelationshipDto> RelationshipsByType(Func<Relationship, bool> relationshipSelector)
        {
            return _family.Relationships.Where(relationshipSelector).Select(r => new RelationshipDto(r));
        }
    }
}