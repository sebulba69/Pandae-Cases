using Godot;
using System;

public class Background : TextureRect
{
    private ShakeableGraphic shakeable;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        shakeable = new ShakeableGraphic()
        {
            X = -1,
            Graphic = new Vector2(RectPosition.x, 0)
        };
    }

    public override void _Process(float delta)
    {
        if (shakeable.ShakeValue > 0)
        {
            shakeable.ShakeValue = (float)Mathf.Lerp(shakeable.ShakeValue, 0, shakeable.ShakeDecay * delta);
            float x = shakeable.GetRandomShakeValue();
            float y = shakeable.GetRandomShakeValue();

            RectPosition = new Vector2(shakeable.X + x, y);

            if (RectPosition.x == 0 && RectPosition.y == 0)
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
}
