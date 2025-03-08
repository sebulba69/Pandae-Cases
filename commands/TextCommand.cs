using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    /// <summary>
    /// Show text on the screen.
    /// </summary>
    public class TextCommand : Command
    {
        public string Text { get; set; }
        public bool Additive { get; set; } = false;

        public TextCommand() : base()
        {
            
        }

        public override void Run(Location location)
        {
            DialogBox dialogBox = location.DialogBox;

            dialogBox.ProcessText(this);
            dialogBox.MessageDisplayed.WaitOne();

            Finish();
        }
    }
}
