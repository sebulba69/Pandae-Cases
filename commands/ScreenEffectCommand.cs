using AceInvestigatorEadnapPandae.Global_Variables;
using AceInvestigatorEadnapPandae.location;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class ScreenEffectCommand : Command
    {
        public bool Flash {  get; set; } = false;
        public bool Shake {  get; set; } = false;
        public string SFX { get; set; } = string.Empty;

        public ScreenEffectCommand() : base()
        {
            
        }

        public override void Run(Location location)
        {
            if (Flash)
            {
                location.PlaySceneAnimation(new AnimationCommand() { Animation = "flash" });
            }

            if (Shake)
            {
                location.DialogBox.Shake();
                location.Background.Shake();
            };

            if (!string.IsNullOrEmpty(SFX))
            {
                string sfxPath = Globals.SFXs[SFX];
                location.SFX.Stream = ResourceLoader.Load<AudioStream>(sfxPath);
                location.SFX.Play();
            }

            Finish();
        }
    }
}
