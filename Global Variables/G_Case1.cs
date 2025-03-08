using AceInvestigatorEadnapPandae.evidence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.Global_Variables
{
    public static class G_Case1
    {
        // animations
        public static string C1_Intro_Do_CloseUps = "do_close_ups";
        public static string C1_Remove_Close_Ups = "remove_close_ups";
        public static string C1_Remove_Box = "remove_box";
        public static string C1_Intro_SmirkfredCloseUp = "smirkfred_close_up";
        public static string C1_Intro_PandaeCloseUp = "pandae_close_up";
        public static string C1_Intro_SmirkfredSlideCenter = "smirkfred_slide_center";
        public static string C1_Smirkfred_Slide_Pandae = "smirkfred_slide_pandae";
        public static string C1_Pandae_Slide = "pandae_slide";

        public static string C1_show_examine = "show_examine";
        public static string C1_hide_examine = "hide_examine";

        // points of interest
        public static string C1_POI_Body = "body";
        public static string Flag_Body = "body";

        public static Evidence GetBodyNotes()
        {
            Evidence bodyNotes = new Evidence()
            {
                Type = EvidenceType.Evidence,
                Name = "Body Notes",
                Description = "Found inside elevator. Died after being hit in the back of the head by a blunt object. Fresh grape juice found on top of a large bruise where he was struck.",
                ImagePath = "res://evidence/item1022_l.png"
            };

            return bodyNotes;
        }
    }
}
