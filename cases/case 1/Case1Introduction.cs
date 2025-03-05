using AceInvestigatorEadnapPandae;
using AceInvestigatorEadnapPandae.cases.case_1;
using AceInvestigatorEadnapPandae.characters;
using AceInvestigatorEadnapPandae.commands;
using AceInvestigatorEadnapPandae.location;
using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Case1Introduction : Location
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        DialogBox = GetNode<DialogBox>("%DialogBox");
        Characters = new Dictionary<string, CharacterNode>()
        {
            { Globals.Pandae, GetNode<CharacterNode>("%pandae") },
            { Globals.Smirkfred, GetNode<CharacterNode>("%smirkfred") }
        };
        Music = GetNode<AudioStreamPlayer>("%AudioStreamPlayer");
        SFX = GetNode<AudioStreamPlayer>("%SFXPlayer");
        Background = GetNode<Background>("%Background");

        commands = Case1Dialog.Introduction;

        List<AnimationPlayer> players = new List<AnimationPlayer>()
        {
            GetNode<AnimationPlayer>("%AnimationPlayer"),
            GetNode<AnimationPlayer>("%AnimationPlayer2"),
            GetNode<AnimationPlayer>("%AnimationPlayer3"),
        };

        RegisterPlayers(players);

        Run();
    }
}
