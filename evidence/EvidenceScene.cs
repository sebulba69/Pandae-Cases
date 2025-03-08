using AceInvestigatorEadnapPandae.evidence;
using Godot;
using System;

public class EvidenceScene : TextureRect
{
    private TextureRect picture;
    private Label name, description;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        picture = GetNode<TextureRect>("%EvidencePicture");
        name = GetNode<Label>("%EvidenceName");
        description = GetNode<Label>("%EvidenceDescription");
    }

    public void SetEvidence(Evidence evidence)
    {
        picture.Texture = ResourceLoader.Load<Texture>(evidence.ImagePath);
        name.Text = evidence.Name;
        description.Text = evidence.Description;
    }
}
