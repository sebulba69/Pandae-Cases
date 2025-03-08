using AceInvestigatorEadnapPandae.commands;
using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.Global_Variables
{
    public static class Globals
    {
        public static string ThinkColor = "#6495ED";

        public static float Text_Normal = 0.03f;
        public static float Text_Slow = 0.06f;
        public static float Text_Typewriter = 0.09f;

        public static string Spd_Normal = $"{{spd {Text_Normal}}}";
        public static string Spd_Slow = $"{{spd {Text_Slow}}}";
        public static string Spd_Typewriter = $"{{spd {Text_Typewriter}}}";

        public static string Pause_Short = "{p 0.1}";
        public static string Pause_Long = "{p 0.2}";
        public static string Pause_Evidence = "{p 1}";

        public static string Ev_Anim_Start = "show_new_evidence";
        public static string Ev_Anim_End = "remove_new_evidence";

        // songs
        public static string AAI2_Investigation_Begin = "res://music/BGM_01.ogg";

        // sfx
        public static string SFX_Huh = "huh";
        public static string SFX_Idea = "idea";
        public static string SFX_Smack = "smack";
        public static string SFX_Candle = "candle";
        public static string SFX_Explode = "explode";
        public static string SFX_Damage1 = "damage1";
        public static string SFX_Evidence = "evidence";
        public static string SFX_Select_Point = "res://sfx/menu_sounds/SE_OLD_01.ogg";

        public static Dictionary<string, string> SFXs = new Dictionary<string, string>() 
        {
            { SFX_Huh, "res://sfx/SE_OLD_19.ogg" },
            { SFX_Idea, "res://sfx/SE_OLD_21.ogg" },
            { SFX_Smack, "res://sfx/SE_OLD_019.ogg" },
            { SFX_Candle, "res://sfx/SE_170.ogg" },
            { SFX_Explode, "res://sfx/SE_OLD_14.ogg" },
            { SFX_Damage1, "res://sfx/SE_OLD_26.ogg" },
            { SFX_Evidence, "res://sfx/SE_OLD_20.ogg" },
        };

        public static Investigation MakeInvestigation(List<string> flags, Dictionary<string, List<Command>> pointsOfInterest, List<string> completionConditions)
        {
            Dictionary<string, bool> investigationFlags = new Dictionary<string, bool>();
            foreach(string flag in flags)
            {
                investigationFlags.Add(flag, false);
            }

            return new Investigation(investigationFlags, pointsOfInterest, completionConditions);
        }
    }
}
