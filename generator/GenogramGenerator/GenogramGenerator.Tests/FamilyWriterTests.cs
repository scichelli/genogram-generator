using System.Diagnostics;
using System.IO;
using GenogramGenerator.Core;
using GenogramGenerator.Core.Writer;

namespace GenogramGenerator.Tests
{
    public class FamilyWriterTestsExplicit
    {
        public void WriteToJson()
        {
            var family = new Family();
            var me = family.Add("me");
            family.Add("mom").Is.TheParentOf(me);
            family.Add("dad").Is.TheParentOf(me);
            DebugWrite(family);
        }

        public void LayoutPrototype()
        {
            var us = new Family();
            var me = new Woman
                {
                    Name = "Subject Person",
                    Generation = 1,
                    DistanceToPrimaryLineage = 1,
                    XPosition = 700
                };
            var mom = new Woman
                {
                    Name = "Mother Person",
                    Generation = 2,
                    DistanceToPrimaryLineage = 1,
                    XPosition = 1050
                };
            var dad = new Man
                {
                    Name = "Father Person",
                    Generation = 2,
                    DistanceToPrimaryLineage = 1,
                    XPosition = 350
                };
            var momsmom = new Woman
                {
                    Name = "Maternal Grandmother",
                    Generation = 3,
                    DistanceToPrimaryLineage = 1,
                    XPosition = 1225
                };
            var momsdad = new Man
                {
                    Name = "Maternal Grandfather",
                    Generation = 3,
                    DistanceToPrimaryLineage = 1,
                    XPosition = 875
                };
            var dadsmom = new Woman
                {
                    Name = "Paternal Grandmother",
                    Generation = 3,
                    DistanceToPrimaryLineage = 1,
                    XPosition = 525
                };
            var dadsdad = new Man
                {
                    Name = "Paternal Grandfather",
                    Generation = 3,
                    DistanceToPrimaryLineage = 1,
                    XPosition = 175
                };
            us.SetAsFamily(me, mom, dad, momsdad, momsmom, dadsdad, dadsmom);
            mom.Is.MarriedTo(dad).AndTheyAreTheParentsOf(me);
            momsdad.Is.MarriedTo(momsmom).AndTheyAreTheParentsOf(mom);
            dadsmom.Is.MarriedTo(dadsdad).AndTheyAreTheParentsOf(dad);

            DebugWrite(us);
        }

        private static void DebugWrite(Family family)
        {
            using (var stream = new MemoryStream())
            {
                new FamilyWriter(family, stream).Write();
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    Debug.Write(reader.ReadToEnd());
                }
            }
        }
    }
}