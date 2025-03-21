﻿using AceInvestigatorEadnapPandae.location;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class Command
    {
        public AutoResetEvent Finished;

        public bool WaitUntilFinished { get; set; } = false;

        public Command()
        {
            Finished = new AutoResetEvent(false);
        }

        public virtual void Run(Location location) {}

        public void Finish()
        {
            Finished.Set();
        }
    }
}
