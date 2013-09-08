using System.IO;
using Newtonsoft.Json;

namespace GenogramGenerator.Core.Writer
{
    public class FamilyWriter
    {
        private readonly TextWriter _writer;
        private readonly Flattener _flattener;

        public FamilyWriter(Family family, TextWriter writer)
        {
            _writer = writer;
            _flattener = new Flattener(family);
        }

        public void Write()
        {
            _writer.Write("var people = ");
            _writer.WriteLine(JsonConvert.SerializeObject(_flattener.Members()));
            _writer.Write("var parents = ");
            _writer.WriteLine(JsonConvert.SerializeObject(_flattener.Parents()));
            _writer.Write("var peers = ");
            _writer.WriteLine(JsonConvert.SerializeObject(_flattener.Peers()));
        }
    }
}
