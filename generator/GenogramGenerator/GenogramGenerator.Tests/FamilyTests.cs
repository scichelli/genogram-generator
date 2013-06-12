using System.Collections.Generic;
using System.Linq;
using GenogramGenerator.Core;
using Should;

namespace GenogramGenerator.Tests
{
    public class FamilyTests
    {
        //Data excerpted from http://www.rhettsmith.com/wp-content/uploads/2013/03/Kennedy-Geno.jpg
        // ReSharper disable InconsistentNaming
        private Person john, joe, rosemary, jackie, jackiesSecondHusband, kathleen, eunice, pat, robert, jean, ted,
            miscarriage, daughter1, daughter2, son1, son2, kathleensHusband, kathleensSecondHusband, ethyl, rdaughter1, rson1, rson2, rson3, rdaughter2, rson4, rdaugher3, rson5, rson6, rson7, rdaugher4,
            joseph, rose, gloria, patrick, patricksWife, pdaughter1, pdaughter2, fitz, mary, toodles, fdaughter2, fson1, fson2, fdaughter3, fson3;
        readonly Family kennedy;
        List<Person> people;
        // ReSharper restore InconsistentNaming

        public FamilyTests()
        {
            kennedy = new Family();
            InitializePeople();

            john.Is.TheChildOf(rose, joseph);
            john.Is.MarriedTo(jackie)
                .AndTheyAreTheParentsOf(miscarriage, daughter1, daughter2, son1, son2);
            jackie.Is.MarriedTo(jackiesSecondHusband);
            joseph.Is.MarriedTo(rose)
                .AndTheyAreTheParentsOf(joe, rosemary, kathleen, eunice, pat, robert, jean, ted);
            kathleen.Is.MarriedTo(kathleensHusband);
            kathleen.Is.MarriedTo(kathleensSecondHusband);
            robert.Is.MarriedTo(ethyl)
                .AndTheyAreTheParentsOf(rdaughter1, rson1, rson2, rson3, rdaughter2, rson4, rdaugher3, rson5, rson6, rson7, rdaugher4);
            new[]{patrick, patricksWife}.AreTheParentsOf(joseph, pdaughter1, pdaughter2);
            fitz.Is.MarriedTo(mary)
                .AndTheyAreTheParentsOf(rose, fdaughter2, fson1, fson2, fdaughter3, fson3);
            gloria.Is.TheRomanticPartnerOf(joseph);
            toodles.Is.TheRomanticPartnerOf(fitz);
        }
        
        public void FindSiblings()
        {
            var rosesSiblings = kennedy.SiblingsOf(rose);
            rosesSiblings.ShouldEqual(new List<Person> { fdaughter2, fson1, fson2, fdaughter3, fson3 });
        }
        
        public void FamilyMembersShouldBeAUniqueList()
        {
            kennedy.Members().Count().ShouldEqual(people.Count);
        }
        
        public void FindChildrenOfTwoParents()
        {
            var children = kennedy.ChildrenOf(new List<Person> { ethyl, robert });
            children.ShouldEqual(new List<Person> { rdaughter1, rson1, rson2, rson3, rdaughter2, rson4, rdaugher3, rson5, rson6, rson7, rdaugher4 });
        }

        public void FindChildrenOfOneParent()
        {
            var children = kennedy.ChildrenOf(robert);
            children.ShouldEqual(new List<Person> { rdaughter1, rson1, rson2, rson3, rdaughter2, rson4, rdaugher3, rson5, rson6, rson7, rdaugher4 });
        }

        public void AskingForTheChildrenOfPeopleWhoDidNotHaveChildrenTogetherShouldGiveEmptyList()
        {
            var children = kennedy.ChildrenOf(new List<Person> { rose, ethyl });
            children.ShouldBeEmpty();
        }

        private void InitializePeople()
        {
            john = kennedy.Add("John");
            joe = kennedy.Add("Joe");
            rosemary = kennedy.Add("Rosemary");
            jackie = kennedy.Add("Jackie");
            jackiesSecondHusband = kennedy.Add("JackiesSecondHusband");
            kathleen = kennedy.Add("Kathleen");
            eunice = kennedy.Add("Eunice");
            pat = kennedy.Add("Pat");
            robert = kennedy.Add("Robert");
            jean = kennedy.Add("Jean");
            ted = kennedy.Add("Ted");
            miscarriage = kennedy.Add("miscarriage");
            daughter1 = kennedy.Add("daughter1");
            daughter2 = kennedy.Add("daughter2");
            son1 = kennedy.Add("son1");
            son2 = kennedy.Add("son2");
            kathleensHusband = kennedy.Add("KathleensHusband");
            kathleensSecondHusband = kennedy.Add("KathleensSecondHusband");
            ethyl = kennedy.Add("Ethyl");
            rdaughter1 = kennedy.Add("rdaughter1");
            rson1 = kennedy.Add("rson1");
            rson2 = kennedy.Add("rson2");
            rson3 = kennedy.Add("rson3");
            rdaughter2 = kennedy.Add("rdaughter2");
            rson4 = kennedy.Add("rson4");
            rdaugher3 = kennedy.Add("rdaugher3");
            rson5 = kennedy.Add("rson5");
            rson6 = kennedy.Add("rson6");
            rson7 = kennedy.Add("rson7");
            rdaugher4 = kennedy.Add("rdaugher4");
            joseph = kennedy.Add("Joseph");
            rose = kennedy.Add("Rose");
            gloria = kennedy.Add("Gloria");
            patrick = kennedy.Add("Patrick");
            patricksWife = kennedy.Add("PatricksWife");
            pdaughter1 = kennedy.Add("pdaughter1");
            pdaughter2 = kennedy.Add("pdaughter2");
            fitz = kennedy.Add("Fitz");
            mary = kennedy.Add("Mary");
            toodles = kennedy.Add("Toodles");
            fdaughter2 = kennedy.Add("fdaughter2");
            fson1 = kennedy.Add("fson1");
            fson2 = kennedy.Add("fson2");
            fdaughter3 = kennedy.Add("fdaughter3");
            fson3 = kennedy.Add("fson3");
            people = new List<Person> { john, joe, rosemary, jackie, jackiesSecondHusband, kathleen, eunice, pat, robert, jean, ted, miscarriage, daughter1, daughter2, 
                                        son1, son2, kathleensHusband, kathleensSecondHusband, ethyl, rdaughter1, rson1, rson2, rson3, rdaughter2, rson4, rdaugher3, rson5, rson6, rson7, rdaugher4, 
                                        joseph, rose, gloria, patrick, patricksWife, pdaughter1, pdaughter2, fitz, mary, toodles, fdaughter2, fson1, fson2, fdaughter3, fson3 };
        }
    }
}
