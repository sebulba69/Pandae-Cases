using AceInvestigatorEadnapPandae;
using AceInvestigatorEadnapPandae.commands;
using Godot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

public class BlipPlayer : AudioStreamPlayer
{
    private const int SKIP_FRAMES = 1;
    private const int DELAY_LENGTH = 10;
    private string currentStream = "";
    private bool blip = false;
    private int timer = 0;

    public int TimerAmount { get; set; } = 1;

    public void SetStream(BlipCommand blips)
    {
        if(currentStream != blips.Blip)
        {
            currentStream = blips.Blip;
            Stream = ResourceLoader.Load<AudioStream>(blips.Blip);
        }

        timer = TimerAmount;
        Stop();
    }

    public void Blip(string letter)
    {
        timer--;

        if (timer < 0)
        {
            timer = TimerAmount;
        }
  
        // Skip blips for spaces, newlines, and punctuation
        if (!string.IsNullOrEmpty(letter))
        {
            if(timer == 0)
            {
                if (TimerAmount == 1 && letter != " ")
                {
                    if(timer == 0)
                        Play();
                }
                else if (TimerAmount == 2)
                {
                    if (timer == 0)
                        Play();
                }
            }
        }
        else
        {
            timer = TimerAmount;
        }
    }
}
