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

        public AnimationCommand() : base() {}

        public override void Run(Location location)
        {
            location.PlaySceneAnimation(this);

            // Don't bother waiting for the animation callback to proceed.
            if (!WaitUntilFinished)
            {
                Finish();
            }
        }
    }
}
