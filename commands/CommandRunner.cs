using AceInvestigatorEadnapPandae.characters;
using AceInvestigatorEadnapPandae.location;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class CommandRunner
    {
        public void Execute(Location location, DialogCommand command)
        {
            bool charCommandNull = command.CharacterCommand == null;

            command.SpeedCommand?.Run(location);

            if (!charCommandNull)
            {
                command.CharacterCommand?.Run(location);
            }
            else
            {
                location.DialogBox.SetShowname(string.Empty);
            }

            if(command.BlipCommand != null)
            {
                Execute(location, command.BlipCommand);
            }

            CharacterNode speaker = null;
            var characterCommand = command.CharacterCommand;

            if (!charCommandNull && characterCommand.Show)
            {
                speaker = location.Characters[command.CharacterCommand.Character];
                speaker.SetTalk(!command.Thinking);
            }

            DialogBox dialogBox = location.DialogBox;

            dialogBox.SetNextArrowVisible(false);
            dialogBox.DialogClicked = new AutoResetEvent(false);

            foreach (var textCommand in command.TextCommands)
            {
                if(textCommand is TextCommand && !command.Thinking)
                {
                    speaker?.SetTalk(true);
                }

                textCommand.Run(location);
                textCommand.Finished.WaitOne();
            }

            if (!charCommandNull && characterCommand.Show)
                speaker.SetTalk(false);

            dialogBox.SetNextArrowVisible(true);

            if(command.WaitUntilFinished)
                dialogBox.DialogClicked.WaitOne();

            command.Finish();
        }

        public void Execute(Location location, AnimationCommand command)
        {
            location.PlaySceneAnimation(command);

            // Don't bother waiting for the animation callback to proceed.
            if (!command.WaitUntilFinished)
            {
                command.Finish();
            }
        }

        public void Execute(Location location, ScreenEffectCommand command)
        {
            if (command.Flash)
            {
                location.PlaySceneAnimation(new AnimationCommand() { Animation = "flash" });
            }

            if(command.Shake)
            {
                location.DialogBox.Shake();
                location.Background.Shake();
            };

            if (!string.IsNullOrEmpty(command.SFX))
            {
                string sfxPath = Globals.SFXs[command.SFX];
                location.SFX.Stream = ResourceLoader.Load<AudioStream>(sfxPath);
                location.SFX.Play();
            }

            command.Finish();
        }

        public void Execute(Location location, MusicCommand command)
        {
            location.Music.Stream = ResourceLoader.Load<AudioStream>(command.Music);
            location.Music.Play();

            command.Finish();
        }

        public void Execute(Location location, TextCommand command) 
        {
            DialogBox dialogBox = location.DialogBox;

            dialogBox.ProcessText(command);
            dialogBox.MessageDisplayed.WaitOne();

            command.Finish();
        }

        public void Execute(Location location, PauseCommand command)
        {
            string speaker = location.DialogBox.Speaker;
            CharacterNode characterNode = null;
            try
            {
                if (speaker != "")
                    characterNode = location.Characters[speaker];
            }
            catch (NullReferenceException) 
            {
                characterNode = null;
            }

            characterNode?.SetTalk(false);

            System.Threading.Thread.Sleep((int)(command.PauseTime * 1000));

            command.Finish();
        }

        public void Execute(Location location, BlipCommand command)
        {
            location.DialogBox.SetBlips(command);
            command.Finish();
        }

        public void Execute(Location location, SpeedCommand command)
        {
            location.DialogBox.SetSpeed(command);
            command.Finish();
        }

        public void Execute(Location location, CharacterCommand command) 
        {
            location.DialogBox.SetShowname(command.Character);

            if(command.Show)
            {
                location.Characters[command.Character].SetCurrentEmote(command.Emote);
            }

            command.Finish();
        }
    }
}
