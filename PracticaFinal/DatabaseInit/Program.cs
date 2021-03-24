using DatabaseInit.Properties;
using System;
using System.Diagnostics;
using System.IO;

namespace DatabaseInit
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = "root";
            string executable = @"C:\xampp\mysql\bin\mysql.exe";
            string arguments = $" -u{username} -p -e \"{Resources.generatedb}\"";

            Process p = Process.Start(executable, arguments);
            p.WaitForExit();
            if (p.ExitCode == 0)
            {
                Console.WriteLine("Database generation successful");
                Console.WriteLine("Initialize Data? Yes=[Enter] No=[Any other key]");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    string newargs = $" -u{username} -p -e \"{Resources.insertdummydata}\"";

                    Process p2 = Process.Start(executable, newargs);
                    p2.WaitForExit();
                    if (p2.ExitCode == 0)
                    {
                        Console.WriteLine("Data initialization completed successfully, press any key to exit the application");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
