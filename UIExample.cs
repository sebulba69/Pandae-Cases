using AceInvestigatorEadnapPandae;
using AceInvestigatorEadnapPandae.commands;
using AceInvestigatorEadnapPandae.location;
using AceInvestigatorEadnapPandae.characters;
using Godot;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceInvestigatorEadnapPandae.Global_Variables;

public class UIExample : Location
{
    private List<Command> commands;
    private Button debugButton;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        DialogBox = GetNode<DialogBox>("%DialogBox");
        Characters = new Dictionary<string, CharacterNode>();

        debugButton = GetNode<Button>("%Debug");


        commands = new List<Command>();
        commands.Add(DialogHelper.MakePandaeDialog(G_Chars.Pandae_Normal, $"There were two ways the culprit could get inside..."));
        commands.Add(DialogHelper.MakePandaeDialog(G_Chars.Pandae_Normal, "First, they opened the door.\nSecond, they BECAME the door."));
        commands.Add(DialogHelper.MakeNoShownameDialog("[color=#FFA500][center]-- My Testimony --[/center][/color]"));

        Characters.Add(G_Chars.Pandae, GetNode<CharacterNode>("%pandae"));

        debugButton.Connect("pressed", this, nameof(Run));
    }

    public void Run()
    {
        debugButton.Disabled = true;
        
        Task.Run(() =>
            {
                foreach (Command command in commands)
                {
                    command.Run(this);
                    command.Finished.WaitOne();
                }
            }
        ).Wait();

        debugButton.Disabled = false;
    }
}
