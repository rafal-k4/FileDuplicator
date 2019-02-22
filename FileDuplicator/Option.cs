using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;
using System.Linq;
using FileDuplicator.Configuration;


namespace FileDuplicator
{
    [Verb("conf", HelpText = "Copy config files")]
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
                if (chosenFolder.Any(x => x.Contains(Const.Aliases.ForDefault)))
                {
                    return new string[] { "default" };
                }
                return chosenFolder;
            }
            set { chosenFolder = value; }
        }

    }

    [Verb("scripts", HelpText = "Copy scripts used for unit tests")]
    public class UnitTestScripts
    {
        [Option('r', Required = false, HelpText = "If appears it reverse process and copy default scripts to targer folder")]
        public bool reverse { get; set; }
        //public string scripts { get; set; }

        private string scriptsFolderName;

        public string ScriptsFolderName
        {
            get
            {
                return scriptsFolderName = reverse ? Const.ScriptsFolderName.DefaultScriptFolder : Const.ScriptsFolderName.ModifiedScriptFolder;
            }
        }


    }
}
