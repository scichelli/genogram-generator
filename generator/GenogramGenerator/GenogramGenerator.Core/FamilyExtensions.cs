using System.Collections.Generic;
using System.Linq;

namespace GenogramGenerator.Core
{
    public static class FamilyExtensions
    {
        public static void AreTheParentsOf(this IEnumerable<Person> parents, params Person[] children)
        {
            foreach (var parent in parents)
            {
                foreach (var child in children)
                {
                    parent.Is.TheParentOf(child);
                }
            }
        }

        public static bool IsOneOf(this RelationshipType type, params RelationshipType[] relationshipTypes)
        {
            return relationshipTypes.Any(relationshipType => relationshipType == type);
        }
    }
}