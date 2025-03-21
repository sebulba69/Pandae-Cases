﻿using AceInvestigatorEadnapPandae.location;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.commands
{
    public class MusicCommand : Command
    {
        public string Music { get; set; }

        public MusicCommand() : base()
        {
            
        }

        public override void Run(Location location)
        {
            location.Music.Stream = ResourceLoader.Load<AudioStream>(Music);
            location.Music.Play();

            Finish();
        }
    }
}
