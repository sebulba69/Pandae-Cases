using AceInvestigatorEadnapPandae.commands;
using AceInvestigatorEadnapPandae.Global_Variables;
using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.cases.case_1
{
    internal static class Case1Dialog
    {
        public static List<Command> Introduction = new List<Command>()
        {
            DialogHelper.MakeNoShownameDialog("[center][color=green]February 8th, 10:25 AM\nSmirkfred Electoral Offices - 1st Floor[/color][/center]", Blips.Typewriter, Globals.Text_Typewriter),
            CommandHelper.PlaySong(Globals.AAI2_Investigation_Begin),
            DialogHelper.MakeSmirkfredDialog(string.Empty, $"{CommandHelper.GetSmackShake()}KOWAKAKAKAKAK!"),
            CommandHelper.PlayAnimation(G_Case1.C1_Intro_Do_CloseUps),
            CommandHelper.PlayAnimation(G_Case1.C1_Intro_SmirkfredCloseUp, true),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, $"Welcome, such investigator!{Globals.Pause_Short} I've been expecting you."),
            CommandHelper.PlayAnimation(G_Case1.C1_Smirkfred_Slide_Pandae, true),
            DialogHelper.MakePandaeDialog(G_Chars.Pandae_Normal, "You're Smirkfred right?"),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "In such flesh, yes."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "I'm sure you've heard a lot about me from my smirky mayoral campaign."),
            DialogHelper.MakePandaeDialog(G_Chars.Pandae_Crossed, "I think I saw you on TV once or twice."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, $"Kowakakakaka...{Globals.Pause_Short} Indeed."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "Well, such citizen, I've heard a lot about you."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "You are such famous private eye, Mr. Pandae."),
            DialogHelper.MakePandaeDialog(G_Chars.Pandae_Crossed, "Uh huh."),
            DialogHelper.MakePandaeDialog(G_Chars.Pandae_Normal, $"{CommandHelper.GetHuhFlash()}Is that the guy over there?"),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "Oh ho ho. I see you are not about such small talk."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal,  "A man of business, yes... I can respect such things."),
            CommandHelper.PlayAnimation(G_Case1.C1_Intro_SmirkfredSlideCenter, true),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "Well, your deductions are such correct."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "That is such body of my good friend and business partner, Solomon Matters."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "It is the situation of much stickiness that I find myself in."),
            DialogHelper.MakeSmirkfredDialog(string.Empty,  $"{CommandHelper.GetCandleLight()}[color=#FFA500][center]*lights candle*[/center][/color]"),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "Times are such changing here in this country."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, $"If such police gets involved,{Globals.Pause_Long} {CommandHelper.GetSmackShake()}I'll be arrested for sure!"),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "I need YOU to discover the gooey truth of this case."),
            CommandHelper.PlayAnimation(G_Case1.C1_Smirkfred_Slide_Pandae, true),
            DialogHelper.MakePandaeDialog(G_Chars.Pandae_Normal, "You're saying you didn't do it?"),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, $"{CommandHelper.GetDamage1Shake()}No no no no!"),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "I would never kill my good buddy, Matterman!"),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "Clearly this is such setup."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "Please, such investigator, find the truth!!!"),
            DialogHelper.MakePandaeDialog(G_Chars.Pandae_Crossed, "I'll see what I can do."),
            DialogHelper.MakePandaeDialog(G_Chars.Pandae_Normal, $"If you actually did do it though,{Globals.Pause_Short} {CommandHelper.GetHuhFlash()}I'm still accusing you."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, $"{CommandHelper.GetSmackShake()}KOWAKAKAKAKAK!"),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "Yes yes yes yes!"),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "I'm aware of your ways, but..."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "I'm sure you've heard of such rumors."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "The law enforcement, the police... they are becoming such more corrupt."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "They would easily get rid of such candidate like me who is fighting for such change."),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, $"{CommandHelper.GetHuhFlash()}YOU are the only one who I can trust."),
            DialogHelper.MakeSmirkfredDialog(string.Empty,  $"{CommandHelper.GetCandleLight()}[color=#FFA500][center]*lights candle*[/center][/color]"),
            DialogHelper.MakeSmirkfredDialog(G_Chars.Smirkfred_Normal, "It is the smirky way, the ultimate path."),
            CommandHelper.PlayAnimation(G_Case1.C1_Pandae_Slide, true),
            DialogHelper.MakePandaeDialog(G_Chars.Pandae_Normal, "Right... whatever you say, man."),
            DialogHelper.MakePandaeDialog(string.Empty, $"[color={Globals.ThinkColor}](Lemme take a closer look at the body.)[/color]"),
            CommandHelper.PlayAnimation(G_Case1.C1_Remove_Box, true),
            CommandHelper.PlayAnimation(G_Case1.C1_Remove_Close_Ups, true),
            CommandHelper.PlayAnimation(G_Case1.C1_show_examine),
            MakeInvestigationTutorial(),
            DialogHelper.MakePandaeDialog(G_Chars.Pandae_Crossed, $"{CommandHelper.GetShake()}Hmmrrgh, it's one of THESE cases.", false),
        };
    
        public static InvestigationCommand MakeInvestigationTutorial()
        {
            List<string> conditions = new List<string>() { G_Case1.Flag_Body };

            List<Command> bodyInvestigation = new List<Command>() 
            {
                CommandHelper.PlayAnimation(G_Case1.C1_hide_examine),
                CommandHelper.PlayAnimation(G_Case1.C1_Intro_Do_CloseUps),
                CommandHelper.PlayAnimation(G_Case1.C1_Intro_PandaeCloseUp, true),
                DialogHelper.MakePandaeDialog(G_Chars.Pandae_Normal, $"[color={Globals.ThinkColor}](Yup, he dead.)[/color]", true),
                DialogHelper.MakePandaeDialog(G_Chars.Pandae_Crossed, $"[color={Globals.ThinkColor}](Looks like someone hit him in the back of the head.)[/color]", true),
                DialogHelper.MakePandaeDialog(G_Chars.Pandae_Normal, $"[color={Globals.ThinkColor}](There's also some weird smell... {CommandHelper.GetHuhFlash()}like grape juice or something.)", true),
                CommandHelper.AddNewEvidence(G_Case1.GetBodyNotes()),
                CommandHelper.SetFlag(G_Case1.Flag_Body)
            };

            Dictionary<string, List<Command>> pointsOfInterest = new Dictionary<string, List<Command>>() { { G_Case1.C1_POI_Body, bodyInvestigation } };

            Investigation investigation = Globals.MakeInvestigation(conditions, pointsOfInterest, conditions);
            
            return new InvestigationCommand() { Investigation = investigation };
        }
    }
}
