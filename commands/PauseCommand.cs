using AceInvestigatorEadnapPandae.characters;
using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class PauseCommand : Command
    {
        public double PauseTime { get; set; } = 0.2;

        public PauseCommand() : base()
        {
            
        }

        public override void Run(Location location)
        {
            string speaker = location.DialogBox.Speaker;
            CharacterNode characterNode = null;
            try
            {
                if (speaker != "")
                    characterNode = location.Characters[speaker];
            }
            catch (NullReferenceException)
            {
                characterNode = null;
            }

            characterNode?.SetTalk(false);

            Task.Delay((int)(PauseTime * 1000)).Wait();

            Finish();
        }
    }
}
