using DatabaseAccess;
using DatabaseAccess.Models;
using Mustache;

namespace MustashMethod
{
    public class GenerateReport
    {
        public static bool CreateJobReport(int JobNumber, string SaveName)
        {
            var FoundJob = MockDatabase.ReturnJobData(JobNumber);

            if (FoundJob != null)
            {
                //This finds the path to the HTML template's current location
                //(this is not done cleanly and future improvement are recommended)
                string relationalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\MustashMethod\Templates\BaseTemplate.html");
                string absolutePath = Path.GetFullPath(relationalPath);

                string templateString = File.ReadAllText(absolutePath);

                string result = CompileReport(JobNumber, FoundJob, templateString);

                if (!CanGenerateFileInTemp(SaveName, result))
                    Console.WriteLine("Error occured when trying to save report");
                return true;
            }
            else
                Console.WriteLine("There was no matching Job Id");

            return false;
        }

        private static string CompileReport(int JobNumber, JobModelMdlLink FoundJob, string templateString)
        {
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

            try
            {
                return Template.Compile(templateString).Render(InputValues);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unable to Compile Report for Job {JobNumber}");
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
                Console.WriteLine(" --------- ");
            }
            return "Generation Issue";
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

            File.Copy(TempLocation, DownloadsLocation, true);
        }

    }
}