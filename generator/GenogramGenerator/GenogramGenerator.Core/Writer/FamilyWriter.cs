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
            writer.WriteLine(JsonConvert.SerializeObject(_flattener.Members()));
            writer.WriteLine(JsonConvert.SerializeObject(_flattener.Relationships()));
            writer.Flush();
        }
    }
}
