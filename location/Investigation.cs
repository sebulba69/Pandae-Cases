using AceInvestigatorEadnapPandae.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.location
{
    public class Investigation
    {
        public EventHandler Complete;
        private Location location;

        private Dictionary<string, bool> flags;
        private Dictionary<string, List<Command>> pointsOfInterest;

        /// <summary>
        /// The flags you need to complete the Investigation
        /// </summary>
        private List<string> completionConditions;

        public Investigation(Dictionary<string, bool> _flags, Dictionary<string, List<Command>> _pointsOfInterest, List<string> _completionConditions)
        {
            flags = _flags;
            pointsOfInterest = _pointsOfInterest;
            completionConditions = _completionConditions;
        }

        public void RegisterEvents(Location _location)
        {
            location = _location;
            location.InvestigateSpotEvent += OnInvestigateSpot;
            location.SetFlagEvent += OnFlagSet;
        }

        private void OnFlagSet(object sender, string flag)
        {
            // don't set the same flag twice
            if (!flags[flag])
            {
                flags[flag] = true;
            }
        }

        private async void OnInvestigateSpot(object sender, string pointOfInterest)
        {
            // no checks here, let it crash if it's not in the list since this dictionary
            // is populated by the case dev, not at runtime
            List<Command> commands = pointsOfInterest[pointOfInterest];

            // must be async void so that _Ready() can finish
            await Task.Run(() =>
            {
                foreach (Command command in commands)
                {
                    command.Run(location);
                    command.Finished.WaitOne();
                }

                int completedConditions = 0;
                foreach (string condition in completionConditions)
                {
                    if (flags[condition])
                    {
                        completedConditions++;
                    }
                }

                if (completionConditions.Count == completedConditions)
                {
                    // deregister events
                    location.InvestigateSpotEvent -= OnInvestigateSpot;
                    location.SetFlagEvent -= OnFlagSet;

                    Complete?.Invoke(null, EventArgs.Empty);
                }
            });
        }
    }
}
