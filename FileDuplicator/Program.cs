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

                startApp.Start(args[0]);

            }
            else
            {
                Console.WriteLine("Choose one of this option {RO - Romania, RU - Russia, PL - Poland, DEF - default} as parameter");
            }
        }
    }
}
