using AceInvestigatorEadnapPandae.Global_Variables;
using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class SpeedCommand : Command
    {
        public float Speed { get; set; } = Globals.Text_Normal;

        public override void Run(Location location)
        {
            base.Run(location);
            runner.Execute(location, this);
        }
    }
}
