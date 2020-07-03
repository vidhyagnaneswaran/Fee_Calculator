using System;
using System.IO;

namespace FeeCalculator.CrossCutting.Helpers
{
    public static class FileHelper
    {
        public const string FilePath = "..\\..\\..\\feecalculator\\src\\FeeCalculator.Data\\JsonData\\";

        public static string Read(string location)
        {
            try
            {
                return File.ReadAllText(location);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Reading File : " + ex);
                Console.WriteLine("Continue ... ");

                return "";
            }
        }
    }
}
