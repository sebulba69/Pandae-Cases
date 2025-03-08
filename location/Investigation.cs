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

        public Dictionary<string, bool> Flags {  get; set; }


        public Investigation()
        {
            Flags = new Dictionary<string, bool>();
        }

        public void RegisterEvents(Location _location)
        {
            location = _location;
            location.InvestigateSpotEvent += OnInvestigateSpot;
        }

        private void OnInvestigateSpot(object sender, string pointOfInterest)
        {

        }
    }
}
