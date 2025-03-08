using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    /// <summary>
    /// Set character blip sound.
    /// </summary>
    public class BlipCommand : Command
    {
        /// <summary>
        /// Stream path for blips, get this from Blips.Male/Blips.Female/Blips.Typewriter
        /// </summary>
        public string Blip {  get; set; }

        public BlipCommand() : base()
        {
            
        }

        public override void Run(Location location)
        {
            location.DialogBox.SetBlips(this);
            Finish();
        }
    }
}
