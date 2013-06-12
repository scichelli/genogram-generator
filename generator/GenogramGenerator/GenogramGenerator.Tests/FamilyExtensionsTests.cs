using System.Collections.Generic;
using GenogramGenerator.Core;
using Should;

namespace GenogramGenerator.Tests
{
    public class FamilyExtensionsTests
    {
        public void AreTheParentsOf_shouldCreateSameResultsAsVerboseAlternatives()
        {
            var us = new Family(); var dad = us.Add(); var mom = us.Add(); var brother = us.Add(); var sister = us.Add(); var cat = us.Add();
            var parents = new[] {mom, dad};

            parents.AreTheParentsOf(brother, sister, cat);

            us.ChildrenOf(parents).ShouldEqual(new List<Person>{brother, sister, cat});
        }
    }
}