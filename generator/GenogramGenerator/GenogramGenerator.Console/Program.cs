using System.IO;
using GenogramGenerator.Core.Writer;
using GenogramGenerator.Tests;

namespace GenogramGenerator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Directory.GetCurrentDirectory();
            using (var file = new StreamWriter(path + @"\family.js"))
            {
                new FamilyWriter(DemoFamily.Create(), file).Write();
            }
        }
    }
}
