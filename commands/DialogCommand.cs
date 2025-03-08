using AceInvestigatorEadnapPandae.Global_Variables;
using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class DialogCommand : Command
    {
        public CharacterCommand CharacterCommand { get; set; }
        public BlipCommand BlipCommand { get; set; }
        public SpeedCommand SpeedCommand { get; set; } = new SpeedCommand() { Speed = Globals.Text_Normal };
        public List<Command> TextCommands { get; set; }

        public bool Thinking { get; set; } = false;

        public DialogCommand()
        {
            WaitUntilFinished = true;
        }

        public override void Run(Location location)
        {
            base.Run(location);
            runner.Execute(location, this);
        }
    }
}
