using MustashMethod;
using System.Diagnostics;

namespace AccessHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var values = MockDatabase.ReturnModelData();

            //foreach (var item in values)
            //{
            //    Console.WriteLine(item.JobNumber);
            //}

            try
            {
                // Copying source file's contents to
                // destination file
                File.Copy(sourceFile, destinationFile);
            }
            catch (IOException iox)
            {
                Console.WriteLine(iox.Message);
            }
        }
    }
}