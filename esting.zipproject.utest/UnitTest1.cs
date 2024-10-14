using System.Text;

namespace esting.zipproject.utest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            TestZip();
        }

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