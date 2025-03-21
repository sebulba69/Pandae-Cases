﻿using AceInvestigatorEadnapPandae.commands;
using AceInvestigatorEadnapPandae.Global_Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae
{
    public static class DialogHelper
    {
        private static Characters characters;
        private static Parser parser;

        static DialogHelper() 
        {
            characters = new Characters();
            parser = new Parser();
        }

        public static DialogCommand MakeNoShownameDialog(string text, string blips = "", float speed = -1)
        {
            if (blips == "")
                blips = Blips.Male;

            // Need compile time constant, using -1.
            if (speed == -1)
                speed = Globals.Text_Normal;

            return new DialogCommand() 
            {
                BlipCommand = new BlipCommand() { Blip = blips },
                SpeedCommand = new SpeedCommand() { Speed = speed },
                TextCommands = parser.Parse(text)
            };
        }

        public static DialogCommand MakePandaeDialog(string emote, string text, bool thinking = false)
        {
            return MakeCharacterDialog(G_Chars.Pandae, emote, text, thinking);
        }

        public static DialogCommand MakeSmirkfredDialog(string emote, string text, bool thinking = false)
        {
            return MakeCharacterDialog(G_Chars.Smirkfred, emote, text, thinking);
        }

        private static DialogCommand MakeCharacterDialog(string name, string emote, string text, bool thinking)
        {
            Character character = characters.GetCharacter(name);

            DialogCommand dialog = new DialogCommand() 
            {
                CharacterCommand = new CharacterCommand()
                { 
                    Character = character.Name,
                    Emote = emote,
                    Show = (!string.IsNullOrEmpty(emote)),
                    Thinking = thinking
                },
                BlipCommand = new BlipCommand() {Blip = character.Blips},
                TextCommands = parser.Parse(text)
            };

            return dialog;
        }
    }
}
