﻿using MustashMethod;

namespace AccessHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (GenerateReport.CreateJobReport(1, "ExampleReport"))
                {

                    GenerateReport.DownloadSelectedFile("ExampleReport");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Report Successfully Created");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Report Failed to Create");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}