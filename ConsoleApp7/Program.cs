// This is a simple console app, that was created to merge separate measurement results into one file, that can be later imported 
// into Excel. 
// Testedout with the output files of the gasket assembly station. 
//
// Put exe into a folder. 
// put measure files into RAW folder next to the exe
// Run exe and output.txt gets created. 
//
// Czibere Attila, 2020-09-30


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            //List in which the output file is generated one by one
            List<string> output = new List<string> { };

            // Filling up logfilesArray with the paths of each individual file. Pay attention to have only measurement files here
            string[] logfilesArray = Directory.GetFiles(Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "RAW"));

            //First logfile's first line is taken as the header line
            output.Add(File.ReadLines(logfilesArray[0]).First());

            //All the files second lines are taken and pasted into the output file. 
            foreach (var item in logfilesArray)
            {
                output.Add(File.ReadLines(item).ElementAtOrDefault(1));
            }

            // Saving the output list into output.txt
            TextWriter tw = new StreamWriter(Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),"output.txt"));

            foreach (String s in output)
                tw.WriteLine(s);

            tw.Close();
            Console.WriteLine("Job finished, hit enter! ");
            Console.ReadLine();

        }
    }
}
