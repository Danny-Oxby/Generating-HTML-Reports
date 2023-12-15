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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}