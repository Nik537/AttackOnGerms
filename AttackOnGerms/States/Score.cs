using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttackOnGerms.States;
using AttackOnGerms.Controls;

namespace AttackOnGerms.States
{
    public class Score
    {
        public static int score = 0;

        private SpriteFont scorefont;

        public Score(SpriteFont font)
        {
            scorefont = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var layer = Button.Layer;
            spriteBatch.DrawString(scorefont, score.ToString(), new Vector2(0, 0), Color.White, 0f, new Vector2(0, 0), 3f, SpriteEffects.None, layer + 0.01f);
            if(score > HighscoresState.highScore)
            {
                HighscoresState.highScore = score;
                Game1.Save();
            }
        }
    }
}