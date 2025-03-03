using Godot;
using System;
using System.Drawing.Text;

public class ShakeableGraphic
{
    public float ShakeStrength { get; set; } = 10;
    public float ShakeDecay { get; set; } = 5;
    public float ShakeValue { get; set; } = 0;
    public float X { get; set; } = -1;
    public Vector2 Graphic { get; set; }


    private RandomNumberGenerator randomNumberGenerator;

    public ShakeableGraphic()
    {
        randomNumberGenerator = new RandomNumberGenerator();
        randomNumberGenerator.Randomize();
    }

    public void Shake()
    {
        ShakeValue = ShakeStrength;
    }

    public float GetRandomShakeValue()
    {
        return randomNumberGenerator.RandfRange(-ShakeValue, ShakeValue);
    }
}

public class BoxGraphic : Control
{
    private TextureRect shownameGraphic, dialogBoxGraphic;
    private ShakeableGraphic shakeable;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        shownameGraphic = GetNode<TextureRect>("%ShownameGraphic");

        shakeable = new ShakeableGraphic()
        {
            X = -1,
            Graphic = new Vector2(RectPosition.x, 776)
        };
    }

    public override void _Process(float delta)
    {
        if (shakeable.ShakeValue > 0) 
        {
            shakeable.ShakeValue = (float)Mathf.Lerp(shakeable.ShakeValue, 0, shakeable.ShakeDecay * delta);
            float x = shakeable.GetRandomShakeValue();
            float y = shakeable.GetRandomShakeValue() + 776;

            RectPosition = new Vector2(shakeable.X + x, y);

            if (RectPosition.x == 0 && RectPosition.y == 776)
                shakeable.ShakeValue = 0;
        }
        else
        {
            shakeable.X = RectPosition.x;
            RectPosition = new Vector2(shakeable.X, shakeable.Graphic.y);
        }
    }

    public void Shake()
    {
        shakeable.Shake();
    }

    public void SetShownameVisibility(bool visibility)
    {
        shownameGraphic.Visible = visibility;
    }
}
