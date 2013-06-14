using System.Collections.Generic;
using GenogramGenerator.Core;
using Should;

namespace GenogramGenerator.Tests
{
    public class FamilyExtensionsTests
    {
        private readonly Family _us;
        private readonly Person _dad, _mom, _brother, _sister, _cat;
        readonly List<Person> _expectedChildren;

        public FamilyExtensionsTests()
        {
             _us = new Family();  _dad = _us.Add();  _mom = _us.Add();  _brother = _us.Add();  _sister = _us.Add();  _cat = _us.Add();
             _expectedChildren = new List<Person> { _brother, _sister, _cat };
        }

        public void AreTheParentsOf_shouldCreateSameResultsAsVerboseAlternatives()
        {
            var parents = new[] {_mom, _dad};

            parents.AreTheParentsOf(_brother, _sister, _cat);

            _us.ChildrenOf(parents).ShouldBeEquivalentTo(_expectedChildren);
        }

        public void ChainAMarriageIntoParenthood()
        {
            _dad.Is.MarriedTo(_mom).AndTheyAreTheParentsOf(_brother, _sister, _cat);

            _us.ChildrenOf(_dad).ShouldBeEquivalentTo(_expectedChildren);
        }

        public void ChainADivorceIntoParenthood()
        {
            _dad.Is.DivorcedFrom(_mom).AndTheyAreTheParentsOf(_brother, _sister, _cat);

            _us.ChildrenOf(_dad).ShouldBeEquivalentTo(_expectedChildren);
        }

        public void ChainARomanceIntoParenthood()
        {
            _dad.Is.TheRomanticPartnerOf(_mom).AndTheyAreTheParentsOf(_brother, _sister, _cat);

            _us.ChildrenOf(_dad).ShouldBeEquivalentTo(_expectedChildren);
        }
    }
}