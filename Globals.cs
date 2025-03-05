using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae
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

        // songs
        public static string AAI2_Investigation_Begin = "res://music/BGM_01.ogg";

        // sfx
        public static string SFX_Huh = "huh";
        public static string SFX_Idea = "idea";
        public static string SFX_Smack = "smack";
        public static string SFX_Candle = "candle";
        public static string SFX_Explode = "explode";
        public static string SFX_Damage1 = "damage1";

        public static Dictionary<string, string> SFXs = new Dictionary<string, string>() 
        {
            { SFX_Huh, "res://sfx/SE_OLD_19.ogg" },
            { SFX_Idea, "res://sfx/SE_OLD_21.ogg" },
            { SFX_Smack, "res://sfx/SE_OLD_019.ogg" },
            { SFX_Candle, "res://sfx/SE_170.ogg" },
            { SFX_Explode, "res://sfx/SE_OLD_14.ogg" },
            { SFX_Damage1, "res://sfx/SE_OLD_26.ogg" },
        };

        // animations
        public static string C1_Intro_Do_CloseUps = "do_close_ups";
        public static string C1_Intro_SmirkfredCloseUp = "smirkfred_close_up";
        public static string C1_Intro_SmirkfredSlideCenter = "smirkfred_slide_center";
        public static string C1_Smirkfred_Slide_Pandae = "smirkfred_slide_pandae";
        public static string C1_Pandae_Slide = "pandae_slide";

        // Easy access strings for characters + emotes
        // Pandae
        public static string Pandae = "Pandae";
        public static string Pandae_Normal = "normal";
        public static string Pandae_Crossed = "crossed";

        // Smirkfred
        public static string Smirkfred = "Smirkfred";
        public static string Smirkfred_Normal = "normal";
    }
}
