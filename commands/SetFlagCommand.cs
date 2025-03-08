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

        public override void Run(Location location)
        {
            base.Run(location);

            location.SetFlag(Flag);

            Finish();
        }
    }
}
