using AceInvestigatorEadnapPandae.cases;
using AceInvestigatorEadnapPandae.evidence;
using AceInvestigatorEadnapPandae.Global_Variables;
using AceInvestigatorEadnapPandae.location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class AddEvidenceCommand : Command
    {
        public Evidence Evidence { get; set; }

        public AddEvidenceCommand() : base()
        {
            WaitUntilFinished = true;
        }

        public override void Run(Location location)
        {
            if (!CaseProgressTracker.Evidence.ContainsKey(Evidence.Name)) 
            {
                CaseProgressTracker.Evidence.Add(Evidence.Name, Evidence);

                EvidenceScene scene = location.GetNode<EvidenceScene>("%EvidenceScene");

                scene.SetEvidence(Evidence);

                List<Command> commands = new List<Command>()
                {
                    CommandHelper.PlayAnimation(Globals.Ev_Anim_Start),
                    DialogHelper.MakeNoShownameDialog($"[color={Globals.ThinkColor}]{CommandHelper.GetNewEvidence()}{Evidence.Name} added to your evidence.{Globals.Pause_Evidence}"),
                    CommandHelper.PlayAnimation(Globals.Ev_Anim_End, true)
                };

                Task.Run(() =>
                {
                    foreach (Command command in commands)
                    {
                        command.Run(location);
                        command.Finished.WaitOne();
                    }
                }).Wait();

                Finish();
            }   
        }
    }
}
