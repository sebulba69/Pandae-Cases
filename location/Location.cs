using AceInvestigatorEadnapPandae.characters;
using AceInvestigatorEadnapPandae.commands;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.location
{
    public class Location : Control
    {
        public EventHandler<string> InvestigateSpotEvent;

        protected List<Command> commands;

        private AnimationCommand currentAnimationCommand = null;

        public DialogBox DialogBox { get; set; }

        public Dictionary<string, CharacterNode> Characters { get; set; }

        public List<AnimationPlayer> Animations { get; set; } = new List<AnimationPlayer>();

        public AudioStreamPlayer Music { get; set; }

        public AudioStreamPlayer SFX { get; set; }

        public Background Background { get; set; }

        protected async void Run()
        {
            await Task.Run(() =>
            {
                foreach (Command command in commands)
                {
                    command.Run(this);
                    command.Finished.WaitOne();
                }
            });
        }

        public void PlaySceneAnimation(AnimationCommand command)
        {
            // If we want to wait until this command finishes, then save it for the callback function.
            if (command.WaitUntilFinished)
            {
                currentAnimationCommand = command;
            }
            else
            {
                currentAnimationCommand = null;
            }
            
            string animation = command.Animation;
            bool animationFound = false;
            foreach (var animationPlayer in Animations)
            {
                if (animationPlayer.HasAnimation(animation))
                {
                    animationPlayer.Play(animation);
                    animationFound = true;
                    break;
                }
            }

            if (!animationFound)
                throw new Exception($"Animation: {animation} not found.");
        }

        protected void RegisterPlayers(List<AnimationPlayer> players)
        {
            foreach (var player in players)
            {
                player.Connect("animation_finished", this, "AnimationComplete");
                Animations.Add(player);
            }
        }

        protected void InvestigateSpot(string pointOfInterest)
        {
            InvestigateSpotEvent?.Invoke(null, pointOfInterest);
        }

        private void AnimationComplete(string animation) 
        {
            if(currentAnimationCommand != null)
            {
                currentAnimationCommand.Finish();
            }   
        }
    }
}
