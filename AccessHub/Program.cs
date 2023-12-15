using MustashMethod;

namespace AccessHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GenerateReport.CreateJobReport(1, "ExampleReport");

                GenerateReport.DownloadSelectedFile("ExampleReport");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Report Successfully Created");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}