using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using DotNetNinjaQuizLib.Domain;

namespace QuizImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            try
            {
                if (!ValidArguments(args))
                {
                    throw new ArgumentException("Usage: QuizImporter path_to_import_csv_file path_to_target_db_file");
                }

                ImportController controller = new ImportController(args[0], args[1]);
                controller.Import();

            }
            catch (Exception ex)
            {
                ReportException(ex);
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Press ENTER to exit..");
                Console.ReadLine();
            }
        }

        private static bool ValidArguments(string[] args)
        {
            return args != null && args.Length == 2
                                && !string.IsNullOrEmpty(args[0])
                                && !string.IsNullOrEmpty(args[1]);
        }

        private static void ReportException(Exception ex)
        {
            const string line = "------------------------------------------------------------------------";
            
            Console.WriteLine();
            
            ConsoleColor defaultBgColor = Console.BackgroundColor;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;            
            
            Console.WriteLine(ex.Message);
            
            Console.BackgroundColor = defaultBgColor;
            Console.ForegroundColor = ConsoleColor.Red;
            
            Console.WriteLine(line);
            Console.WriteLine(ex.ToString());
            Console.WriteLine(line);
        }
    }
}
