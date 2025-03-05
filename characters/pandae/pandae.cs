using AceInvestigatorEadnapPandae.characters;
using Godot;
using System;

public class Pandae : CharacterNode
{
    public override void SetTalk(bool talk)
    {
        base.SetTalk(talk);

        if(!talk && currentEmote == "crossed")
        {
            GetNode<Sprite>("%CrossedEar").Visible = false;
        }
    }
}
