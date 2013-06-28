using System.Collections.Generic;

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
    }
}