using AceInvestigatorEadnapPandae;
using AceInvestigatorEadnapPandae.commands;
using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

public class DialogBox : Control
{
    private bool processing = false;
    private float timePassed = 0f;
    private float delay = 0f;
    private string parsedText = "";

    private BlipPlayer blipPlayer;
    private RichTextLabel text, showname;
    private TextureRect nextArrow;
    private BoxGraphic boxGraphic;
    private Regex bbcodeRegex;
    private AudioStreamPlayer clickSFX;

    public AutoResetEvent MessageDisplayed;
    public AutoResetEvent DialogClicked;

    private string speaker;
    public string Speaker { get => speaker; }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        text = GetNode<RichTextLabel>("%Text");
        showname = GetNode<RichTextLabel>("%Showname");
        boxGraphic = GetNode<BoxGraphic>("%BoxGraphic");
        nextArrow = GetNode<TextureRect>("%NextArrow");
        clickSFX = GetNode<AudioStreamPlayer>("%ClickSfx");
        blipPlayer = GetNode<BlipPlayer>("%BlipPlayer");
        bbcodeRegex = new Regex("@\"\\[.*\\].*?\\[/\\]\"");
        MessageDisplayed = new AutoResetEvent(false);

        Connect("gui_input", this, nameof(OnGuiInputEvent));
    }
    /*
    public override void _Process(float delta)
    {
        
        if (processing)
        {
            timePassed += delta;

            if(timePassed >= delay)
            {
                int numberOfLetters = (int)(timePassed / delay); // find out how many letters we're owed (should be at least 1)
                
                // the last letter
                string letter = string.Empty;
                for(int i = 0; i < numberOfLetters; i++)
                {
                    NextLetter();

                    letter = GetLastVisibleChar();

                    // we hit the end
                    if (letter == string.Empty || !processing)
                        break;

                    // subtract from our delay to compensate for overshooting the timing
                    timePassed -= delay;
                }

                // check to make sure we're not over-displaying letters
                if(letter != string.Empty || !processing)
                {
                    // finally, blip on the last letter
                    blipPlayer?.Blip(letter);

                    if (",.?".Contains(letter))
                    {
                        timePassed -= 0.1f; // Extend delay for commas, periods and question marks
                    }
                }
            }
        }
    }*/

    public void SetShowname(string shownameText)
    {
        showname.Visible = !string.IsNullOrEmpty(shownameText);
        speaker = (showname.Visible) ? shownameText : "";
        boxGraphic.SetShownameVisibility(showname.Visible);
        showname.Text = shownameText;
    }

    public void Shake()
    {
        boxGraphic.Shake();
    }

    public void ProcessText(TextCommand command)
    {
        if (command.Additive) 
        {
            text.AppendBbcode(command.Text);
        }
        else
        {
            text.VisibleCharacters = 0;
            timePassed = 0;
            text.BbcodeText = command.Text;
        }

        MessageDisplayed = new AutoResetEvent(false);
        parsedText = bbcodeRegex.Replace(text.Text, string.Empty);

        processing = true;

        Start();
    }

    public void Start()
    {
        // separate the conversion here so we can re-use this value later
        int delay_converted = (int)(delay * 1000);

        int delay_ms = delay_converted;

        string letter = string.Empty;

        while (processing)
        {
            NextLetter();
            letter = GetLastVisibleChar();

            if (processing)
            {
                blipPlayer?.Blip(letter);
            }

            if (",.?".Contains(letter))
            {
                delay_ms += 50;
            }
            else
            {
                delay_ms = delay_converted;
            }

            Task.Delay(delay_ms).Wait();
        }
    }

    public void SetSpeed(SpeedCommand speed)
    {
        delay = speed.Speed;

        if(delay <= Globals.Text_Normal)
        {
            blipPlayer.TimerAmount = 2;
        }
        else
        {
            blipPlayer.TimerAmount = 1;
        }
    }

    public void SetBlips(BlipCommand blips)
    {
        blipPlayer?.SetStream(blips);
    }

    public void SetNextArrowVisible(bool visible) 
    {
        nextArrow.Visible = visible;
    }

    public void Skip()
    {
        if (processing)
        {
            nextArrow.Visible = true;
            processing = false;
            text.VisibleCharacters = parsedText.Length;
            MessageDisplayed.Set();
        }
    }

    public void NextLetter()
    {
        if(text.VisibleCharacters + 1 > parsedText.Length)
        {
            processing = false;
            MessageDisplayed.Set();
            return;
        }

        text.VisibleCharacters++;
    }

    public string GetLastVisibleChar()
    {
        if(text.VisibleCharacters - 1 < parsedText.Length)
        {
            return (parsedText != "") ? parsedText[text.VisibleCharacters - 1].ToString() : string.Empty;
        }
        else
        {
            return string.Empty;
        }
    }

    public void OnGuiInputEvent(InputEvent @event)
    {
        if (!nextArrow.Visible)
            return;

        if(@event is InputEventMouseButton eventButton && eventButton.Pressed)
        {
            if ((ButtonList)eventButton.ButtonIndex == ButtonList.Left) 
            {
                text.VisibleCharacters = 0;
                clickSFX.Play();
                speaker = "";
                DialogClicked?.Set();
            }
        }
    }

}
