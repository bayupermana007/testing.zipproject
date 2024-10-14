using System;
using System.Text;

namespace testing.zipcomposer
{
    public static class Program
    {
        //Console.WriteLine("Hello, World!");
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.WriteLine("Start Zipping");
            var zipold = new ZipOld();
            zipold.TestZip();
            Console.WriteLine("Finish Zipping");
        }
    }

    public class ZipOld
    {
        public void TestZip()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "output-old", Guid.NewGuid().ToString());
            Directory.CreateDirectory(path);
            Console.WriteLine(path);
            var input = File.Open("test.xlsx", FileMode.Open);
            input.Position = 0;
            CreateZip(path, input, "test.xlsx");
            input.Dispose();
        }

        private void CreateZip(string path, Stream inputStream, string inputFileName)
        {
            using var zip = new Ionic.Zip.ZipFile();
            zip.AddEntry(inputFileName, inputStream);
            zip.MaxOutputSegmentSize = 1024 * 64;
            zip.Save(Path.Combine(path, "test.zip"));
        }
    }
}
