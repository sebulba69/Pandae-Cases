using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    /// <summary>
    /// Set a character's emote
    /// </summary>
    public class CharacterCommand : Command
    {
        public string Character {  get; set; }
        public string Emote { get; set; }
        public bool Show { get; set; } = true;
        public bool Thinking { get; set; } = true;

        public CharacterCommand() : base()
        {
            
        }

        public override void Run(Location location)
        {
            location.DialogBox.SetShowname(Character);

            if (Show)
            {
                location.Characters[Character].SetCurrentEmote(Emote, Thinking);
            }

            Finish();
        }
    }
}
