using System;
using System.Collections.Generic;
using System.Text;
using CommandLine;

namespace FileDuplicator
{

    public class Option
    {
        [Option('b', Required = false, HelpText = "Enables Browser Link")]
        public bool IsBrowserLink { get; set; }
        [Value(0, Max = 1, Required = true, MetaName = "Folder Name", HelpText = "Choose wich folder will be copied")]
        public IEnumerable<string> ChosenFolder { get; set; }
    }
}
