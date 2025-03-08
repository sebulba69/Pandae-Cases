using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class InvestigationCommand : Command
    {
        public Investigation Investigation { get; set; }

        public InvestigationCommand() : base()
        {
            
        }

        public override void Run(Location location)
        {
            Investigation.RegisterEvents(location);
            Investigation.Complete += OnInvestigationComplete;
        }

        public void OnInvestigationComplete(object sender, EventArgs e)
        {
            Finish();
        }
    }
}
