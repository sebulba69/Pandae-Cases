using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceInvestigatorEadnapPandae.characters
{
    public class CharacterNode : Node2D
    {
        private string currentEmote = "";
        private AnimationPlayer basePlayer, blinkPlayer, talkPlayer;
        private Sprite blinkSprite, talkSprite;

        public override void _Ready()
        {
            basePlayer = GetNode<AnimationPlayer>("%BasePlayer");
            blinkPlayer = GetNode<AnimationPlayer>("%BlinkPlayer");
            talkPlayer = GetNode<AnimationPlayer>("%TalkPlayer");
            blinkSprite = GetNode<Sprite>("%Blink");
            talkSprite = GetNode<Sprite>("%Talk");
        }

        public void SetCurrentEmote(string newEmote) 
        {
            currentEmote = newEmote;
            basePlayer.Play(newEmote);

            blinkPlayer.Play(newEmote);

            if (talkSprite.Visible) 
            {
                talkPlayer.Play(newEmote);
            }
            else
            {
                talkPlayer.Stop();
            }
        }

        public void SetTalk(bool talk)
        {
            if (talk && !talkSprite.Visible) 
            {
                talkSprite.Visible = true;
                talkPlayer.Play(currentEmote);
            }
            else if (!talk)
            {
                talkPlayer.Stop();
                talkSprite.Visible = false;
            }
        }
    }
}
