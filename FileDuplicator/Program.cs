using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileDuplicator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var asd = new string[] { "ro", "-b"};
            Parser.Default.ParseArguments<Option>(asd).
                WithParsed(x =>
                {
                    Console.WriteLine(x.ChosenFolder.First());
                    Console.WriteLine(x.IsBrowserLink);
                });
            ;
        }
    }

}
