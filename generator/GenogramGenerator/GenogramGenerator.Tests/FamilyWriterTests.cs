using System.Diagnostics;
using System.IO;
using GenogramGenerator.Core;
using GenogramGenerator.Core.Writer;

namespace GenogramGenerator.Tests
{
    public class FamilyWriterTests
    {
        public void WriteToJson()
        {
            var family = new Family();
            var me = family.Add("me");
            family.Add("mom").Is.TheParentOf(me);
            family.Add("dad").Is.TheParentOf(me);
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