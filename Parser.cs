using AceInvestigatorEadnapPandae.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae
{

    public class Parser
    {
        private string shakeIdentifier = "s";
        private string flashIdentifier = "f";
        private string charIdentifier = "char";
        private string camIdentifier = "cam";
        private string pauseIdentifier = "p";
        private string blipIdentifier = "blip";
        private string spdIdentifier = "spd";
        private string effIdentifier = "eff";

        public List<Command> Parse(string text) 
        {
            List<Command> commands = new List<Command>();
            bool parsing = false;
            bool additive = false;
            string parsedText = "";
            int count = 0;

            for (int i = 0; i < text.Length; i++) 
            {
                char c = text[i];

                if(c == '{') // if we are at the start of a command
                {
                    // This case is only hit if we have parsed text before we hit this point.
                    // We want to cut it off and not include it in our command.
                    if(parsedText != "")
                    {
                        commands.Add(new TextCommand() { Text = parsedText, Additive = additive });
                        if(!additive)
                            additive = true;

                        count++;
                        parsedText = "";
                    }

                    parsedText += c;
                    parsing = true;
                }
                else if(c == '}' && parsing) // if we are at the end of a command
                {
                    string parsed = parsedText.Substring(1, parsedText.Length - 1);
                    commands.Add(ParseCommandStr(parsed));
                    parsing = false;
                    parsedText = "";
                }
                else if(c == '{' && parsing)
                {
                    throw new Exception($"Cannot have nested command where text = {parsedText} where input is {text}");
                }
                else
                {
                    parsedText += c;
                }
            }

            if(parsedText != "")
                commands.Add(new TextCommand() { Text = parsedText, Additive = additive });
            
            return commands;
        }

        private Command ParseCommandStr(string commandStr)
        {
            string[] commandSplit = commandStr.Split(' ');
            string identifier = commandSplit[0];

            if(identifier == charIdentifier)
            {
                return new CharacterCommand()
                {
                    Character = commandSplit[1],
                    Emote = commandSplit[2]
                };
            }
            else if (identifier == blipIdentifier)
            {
                return new BlipCommand()
                {
                    Blip = commandSplit[1]
                };
            }
            else if (identifier == spdIdentifier)
            {
                return new SpeedCommand()
                {
                    Speed = float.Parse(commandSplit[1])
                };
            }
            else if (identifier == pauseIdentifier)
            {
                return new PauseCommand()
                {
                    PauseTime = double.Parse(commandSplit[1])
                };
            }
            else if (identifier == effIdentifier)
            {
                //  $"{{eff {flash} {shake} {sfx}}}";
                return new ScreenEffectCommand() 
                {
                    Flash = bool.Parse(commandSplit[1]),
                    Shake = bool.Parse(commandSplit[2]),
                    SFX = commandSplit[3]
                };
            }
            else
            {
                throw new Exception($"Could not identify command: {identifier}");
            }
        }
    }
}
