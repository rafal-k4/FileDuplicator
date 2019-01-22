using System;
using CommandLine;
using CommandLine.Text;


namespace FileDuplicator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] asd = new string[] { "ro" };
            //var options = new Option();

            var parser = Parser.Default.ParseArguments<Option>(asd);
            var text = parser.WithParsed(x =>
           {
               Console.WriteLine(x.ChosenFolder);
               Console.WriteLine((x.IsBrowserLink)? "Yup":"NOPE");
           });



            if(args.Length != 0)
            {
                var startApp = new AppLogic();

                startApp.Start(args);

            }
            else
            {
                Console.WriteLine("Folder not found, please insert Configuration Folder Name and addidtionally -b as parameter in case to activate Browser Link ");
            }
        }
    }

    public class Option
    {
        [Option('b', Required = false)]
        public bool IsBrowserLink { get; set; }
        [Value(0,Required = true)]
        public string ChosenFolder { get; set; }
    }
}
