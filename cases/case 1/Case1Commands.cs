using AceInvestigatorEadnapPandae.commands;
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
            DialogHelper.MakeSmirkfredDialog(string.Empty, $"{CommandHelper.GetSmackShake()}KOWAKKAKAKAK!"),
            CommandHelper.PlayAnimation(Globals.C1_Intro_Do_CloseUps),
            CommandHelper.PlayAnimation(Globals.C1_Intro_SmirkfredCloseUp, true),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal, $"Welcome, such investigator!{Globals.Pause_Short} I've been expecting you."),
            CommandHelper.PlayAnimation(Globals.C1_Smirkfred_Slide_Pandae, true),
            DialogHelper.MakePandaeDialog(Globals.Pandae_Normal, "You're Smirkfred right?"),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal, "In such flesh, yes."),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal, "I'm sure you've heard a lot about me from my smirky mayoral campaign."),
            DialogHelper.MakePandaeDialog(Globals.Pandae_Crossed, "I think I saw you on TV once or twice."),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal, $"Kowkakakaka...{Globals.Pause_Short} Indeed."),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal, "Well, such citizen, I've heard a lot about you."),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal, "You are such famous private eye, Mr. Pandae."),
            DialogHelper.MakePandaeDialog(Globals.Pandae_Crossed, "Uh huh."),
            DialogHelper.MakePandaeDialog(Globals.Pandae_Normal, $"{CommandHelper.GetHuhFlash()}Is that the guy over there?"),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal, "Oh ho ho. I see you are not about such small talk."),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal,  "A man of business, yes... I can respect such things."),
            CommandHelper.PlayAnimation(Globals.C1_Intro_SmirkfredSlideCenter, true),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal, "Well, your deductions are such correct."),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal, "That is such body of my good friend and business partner, Solomon Matters."),
            DialogHelper.MakeSmirkfredDialog(Globals.Smirkfred_Normal, "It is the situation of much stickiness that I find myself in."),
            DialogHelper.MakeSmirkfredDialog(string.Empty,  $"{CommandHelper.GetCandleLight()}[color=#FFA500][center]*lights candle*[/center][/color]"),
        };
    }
}
