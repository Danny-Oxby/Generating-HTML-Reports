using Mustache;
using System.IO.Compression;
using System.Reflection;

namespace MustashMethod
{
    public class GenerateReport
    {

        public static void CreateJobReport(int JobNumber, string SaveName)
        {
            var FoundJob = MockDatabase.ReturnJobData(JobNumber);

            if ( FoundJob != null)
            {
                //string DirectoryLocation = Assembly.GetExecutingAssembly().Location;
                //string DirectoryLocation = Environment.CurrentDirectory;
                string Path = "C:\\Users\\oxbyd\\OneDrive\\Documents\\HomeProjects\\HTMLTemplates\\GenerateTemplates\\MustashMethod\\Templates\\BaseTemplate.html";
                string templateString = File.ReadAllText(Path);
                //string templateString = File.ReadAllText($"./Templates/BaseTemplate.html");

                var InputValues = new
                {
                    Header = $"Invoice for Job {JobNumber}",
                    JobId = JobNumber,
                    Location = FoundJob.JobValues.JobLocation,
                    Worker = FoundJob.WorkerId,
                    Customer = FoundJob.CustomerID,
                    OpeningPara = "This is an example of a personalised message to the client, such as the workers notes about the job",
                    StartTime = FoundJob.JobValues.WorkDateStart,
                    EndTime = FoundJob.JobValues.WorkDateEnd,
                    Labour = FoundJob.JobValues.CostOfLabour,
                    Transport = FoundJob.JobValues.CostOfTransport,
                    MaterialList = FoundJob.JobValues.ListOfMaterials,
                    Total = FoundJob.JobValues.TotalCost,
                    EndingPara = "This is another example of a personalised message to the client, such as a company message or ending",
                };

                string result = Template.Compile(templateString).Render(InputValues);

                if (!CanGenerateFileInTemp(SaveName, result))
                    Console.WriteLine("Error occured when trying to save report");
            }
            else
                Console.WriteLine("There was no matching Job Id");
        }

        private static bool CanGenerateFileInTemp(string SaveName, string Report)
        {
            try
            {
                //create a string to the desired file in the temp folder
                string SaveLocation = Path.Combine(Path.GetTempPath(), $"{SaveName}.html");

                //Create File - If file already exists overwrite (open -> save data -> close)
                File.WriteAllText(SaveLocation, Report);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR HERE");
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                Console.WriteLine(" --------- ");
            }

            return false;
        }

        //In actual production the temp file will likely be sent over a http protocall
        //alowing it to be downloaded by the user this method will replace that funcationality
        //for this example project
        public static void DownloadSelectedFile(string SaveName)
        {
            string TempLocation = Path.Combine(Path.GetTempPath(), $"{SaveName}.html");

            //"C:\Users\USER_NAME\Downloads"
            string? DownloadsLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", $"{SaveName}.html");

            File.Copy(TempLocation, DownloadsLocation);
        }

    }
}