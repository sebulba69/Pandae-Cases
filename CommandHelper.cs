using AceInvestigatorEadnapPandae.commands;
using AceInvestigatorEadnapPandae.Global_Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae
{
    /// <summary>
    /// For general commands that are not dialog.
    /// </summary>
    public static class CommandHelper
    {
        private static CommandMarkups commandMarkups;


        static CommandHelper() 
        {
            commandMarkups = new CommandMarkups();
        }

        public static string GetHuhFlash()
        {
            return commandMarkups.Effect(flash: true, shake: false, sfx: Globals.SFX_Huh);
        }

        public static string GetIdeaFlash()
        {
            return commandMarkups.Effect(flash: true, shake: false, sfx: Globals.SFX_Huh);
        }

        public static string GetSmackShake()
        {
            return commandMarkups.Effect(flash: true, shake: true, sfx: Globals.SFX_Smack);
        }

        public static string GetDamage1Shake()
        {
            return commandMarkups.Effect(flash: true, shake: true, sfx: Globals.SFX_Damage1);
        }

        public static string GetCandleLight()
        {
            return commandMarkups.Effect(flash: true, shake: true, sfx: Globals.SFX_Candle);
        }

        public static AnimationCommand PlayAnimation(string animation, bool waitUntilFinsihed = false) => new AnimationCommand() { Animation = animation, WaitUntilFinished = waitUntilFinsihed };
        
        public static MusicCommand PlaySong(string song) => new MusicCommand() { Music = song };

        public static ScreenEffectCommand DoEffect(bool flash = false, bool shake = false, string sfx = "") => new ScreenEffectCommand() { Flash = flash, Shake = shake, SFX = sfx};
    }
}
