using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParallelExecution
{
    class Program
    {
        static int totalAndCount;

        static void Main(string[] args)
        {
            string projectDir = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string folderName = $"{projectDir}\\ParallelExecTest";

            var files = Directory.GetFiles(folderName);

            //Parallel.ForEach<string>(files, GetAndCount);
            var processedFiles = files
                                .AsParallel();

            foreach (var processedFile in processedFiles)
            {
                GetAndCount(processedFile);
            }

            Console.WriteLine($"Total 'and' count is {totalAndCount}");
            Console.ReadKey();
        }

        private static void GetAndCount(string file)
        {
            int andCount = 0;

            string text = File.ReadAllText(file);
            var andMatches = Regex.Matches(text, "and");
            andCount = andMatches.Count;

            totalAndCount += andCount;
        }
    }
}
