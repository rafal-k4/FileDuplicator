using System;


namespace FileDuplicator
{
    class Program
    {
        static void Main(string[] args)
        {
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
}
