using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class ScreenEffectCommand : Command
    {
        public bool Flash {  get; set; } = false;
        public bool Shake {  get; set; } = false;
        public string SFX { get; set; } = string.Empty;

        public override void Run(Location location)
        {
            base.Run(location);
            runner.Execute(location, this);
        }
    }
}
