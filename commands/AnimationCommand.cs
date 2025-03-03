using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class AnimationCommand : Command
    {
        public string Animation { get; set; }

        public override void Run(Location location)
        {
            base.Run(location);
            runner.Execute(location, this);
        }
    }
}
