using AceInvestigatorEadnapPandae.characters;
using AceInvestigatorEadnapPandae.Global_Variables;
using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class DialogCommand : Command
    {
        public CharacterCommand CharacterCommand { get; set; }
        public BlipCommand BlipCommand { get; set; }
        public SpeedCommand SpeedCommand { get; set; } = new SpeedCommand() { Speed = Globals.Text_Normal };
        public List<Command> TextCommands { get; set; }

        public bool Thinking { get; set; } = false;

        public DialogCommand()
        {
            WaitUntilFinished = true;
        }

        public override void Run(Location location)
        {
            base.Run(location);

            bool charCommandNull = CharacterCommand == null;

            SpeedCommand?.Run(location);

            if (!charCommandNull)
            {
                CharacterCommand?.Run(location);
            }
            else
            {
                location.DialogBox.SetShowname(string.Empty);
            }

            if (BlipCommand != null)
            {
                BlipCommand.Run(location);
            }

            CharacterNode speaker = null;
            var characterCommand = CharacterCommand;

            if (!charCommandNull && characterCommand.Show)
            {
                speaker = location.Characters[CharacterCommand.Character];
                speaker.SetTalk(!Thinking);
            }

            DialogBox dialogBox = location.DialogBox;

            dialogBox.SetNextArrowVisible(false);
            dialogBox.DialogClicked = new AutoResetEvent(false);

            foreach (var textCommand in TextCommands)
            {
                if (textCommand is TextCommand && !Thinking)
                {
                    speaker?.SetTalk(true);
                }

                textCommand.Run(location);
                textCommand.Finished.WaitOne();
            }

            if (!charCommandNull && characterCommand.Show)
                speaker.SetTalk(false);

            dialogBox.SetNextArrowVisible(true);

            if (WaitUntilFinished)
                dialogBox.DialogClicked.WaitOne();

            Finish();
        }
    }
}
