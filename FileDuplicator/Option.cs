using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using System.Linq;
using FileDuplicator.Configuration;


namespace FileDuplicator
{

    public class Option
    {
        [Option('b', Required = false, HelpText = "Enables Browser Link")]
        public bool IsBrowserLink { get; set; }
       
        //public IEnumerable<string> ChosenFolder { get; set; }


        private IEnumerable<string> chosenFolder;

        [Value(0, Max = 1, Required = true, MetaName = "Folder Name", HelpText = "Choose wich folder will be copied")]
        public IEnumerable<string> ChosenFolder
        {
            get
            {
                if(chosenFolder.Any(x => x.Contains(Const.Aliases.ForDefault)))
                {
                    return new string[] { "default" };
                }
                return chosenFolder;
            }
            set { chosenFolder = value; }
        }

    }
}
