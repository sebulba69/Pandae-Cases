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
        protected string currentEmote = "";
        private AnimationPlayer basePlayer, blinkPlayer, talkPlayer;
        private Sprite blinkSprite, talkSprite;
        private bool isThinking;

        public override void _Ready()
        {
            basePlayer = GetNode<AnimationPlayer>("%BasePlayer");
            blinkPlayer = GetNode<AnimationPlayer>("%BlinkPlayer");
            talkPlayer = GetNode<AnimationPlayer>("%TalkPlayer");
            blinkSprite = GetNode<Sprite>("%Blink");
            talkSprite = GetNode<Sprite>("%Talk");
        }

        public void SetCurrentEmote(string newEmote, bool thinking) 
        {
            currentEmote = newEmote;
            basePlayer.Play(newEmote);

            blinkPlayer.Play(newEmote);

            isThinking = thinking;

            if (talkSprite.Visible) 
            {
                talkPlayer.Play(newEmote);
            }
            else
            {
                talkPlayer.Stop();
            }
        }

        public virtual void SetTalk(bool talk)
        {
            if (talk) 
            {
                if (!isThinking) 
                {
                    if(!talkSprite.Visible)
                    {
                        talkSprite.Visible = true;
                        talkPlayer.Play(currentEmote);
                    }
                }
                else
                {
                    talkPlayer.Stop();
                    talkSprite.Visible = false;
                }
            }
            else
            {
                talkPlayer.Stop();
                talkSprite.Visible = false;
            }
        }
    }
}
