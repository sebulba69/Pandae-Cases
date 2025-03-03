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

        public override void Run(Location location)
        {
            base.Run(location);
            runner.Execute(location, this);
        }
    }
}
