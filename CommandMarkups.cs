using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae
{
    public class CommandMarkups
    {
        public string Pause(double delay) => $"{{p {delay}}}";
        
        public string Blip(string gender) => $"{{blip {gender}}}";

        public string Animation(string animation) => $"{{anim {animation}}}";

        public string Character(string characterName, string emote, bool nowait)
        {
            string command = $"{{char {characterName} {emote}";

            if (nowait)
            {
                command += $"nowait}}";
            }
            else
            {
                command += "}";
            }

            return command;
        }

        public string Effect(bool flash = false, bool shake = false, string sfx = "")
        {
            return $"{{eff {flash} {shake} {sfx}}}";
        }
    }
}
