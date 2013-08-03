using System.IO;
using Newtonsoft.Json;

namespace GenogramGenerator.Core.Writer
{
    public class FamilyWriter
    {
        private readonly Stream _stream;
        private readonly Flattener _flattener;

        public FamilyWriter(Family family, Stream stream)
        {
            _stream = stream;
            _flattener = new Flattener(family);
        }

        public void Write()
        {
            var writer = new StreamWriter(_stream);
            writer.Write("var people = ");
            writer.WriteLine(JsonConvert.SerializeObject(_flattener.Members()));
            writer.Write("var parents = ");
            writer.WriteLine(JsonConvert.SerializeObject(_flattener.Parents()));
            writer.Write("var peers = ");
            writer.WriteLine(JsonConvert.SerializeObject(_flattener.Peers()));
            writer.Flush();
        }
    }
}
