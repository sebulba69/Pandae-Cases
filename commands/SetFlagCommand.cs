using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class SetFlagCommand : Command
    {
        public string Flag {  get; set; }

        public SetFlagCommand() : base()
        {
            
        }

        public override void Run(Location location)
        {
            location.SetFlag(Flag);

            Finish();
        }
    }
}
