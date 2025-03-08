using AceInvestigatorEadnapPandae.evidence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.cases
{
    public static class CaseProgressTracker
    {
        public static Dictionary<string, Evidence> Evidence {  get; set; }

        static CaseProgressTracker()
        {
            if(Evidence == null)
                Evidence = new Dictionary<string, Evidence>();
        }
    }
}
