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
            var us = DemoFamily.Create();
            DebugWrite(us);
        }

        private static void DebugWrite(Family family)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new StreamWriter(stream);
                new FamilyWriter(family, writer).Write();
                writer.Flush();
                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    Debug.Write(reader.ReadToEnd());
                }
                writer.Dispose();
            }
        }
    }
}