using AceInvestigatorEadnapPandae;
using AceInvestigatorEadnapPandae.cases.case_1;
using AceInvestigatorEadnapPandae.characters;
using AceInvestigatorEadnapPandae.commands;
using AceInvestigatorEadnapPandae.Global_Variables;
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
		TextureButton buttonScene = GetNode<TextureButton>("%ButtonScene");
		buttonScene.Connect("pressed", this, "BodyExamined");

		DialogBox = GetNode<DialogBox>("%DialogBox");
		Characters = new Dictionary<string, CharacterNode>()
		{
			{ G_Chars.Pandae, GetNode<CharacterNode>("%pandae") },
			{ G_Chars.Smirkfred, GetNode<CharacterNode>("%smirkfred") }
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

	private void BodyExamined()
	{
		InvestigateSpot(G_Case1.C1_POI_Body);
	}
}
