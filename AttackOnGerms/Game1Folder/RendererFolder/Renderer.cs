using System;
using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using AttackOnGerms;
using AttackOnGerms.States;

using AttackOnGerms.Game1Folder.HumanPlayerFolder;

namespace AttackOnGerms.Game1Folder.RendererFolder
{
    public class Renderer
    {
        public static Rectangle rectangleToDraw;
        public static float enemyScale;
        public static float enemyRotation;
        public static Color shieldColor;
        public static Vector2 origin;

        //SpriteBatch _spriteBatch, Texture2D atlas, float gunRotation, Controller controller, Vector2[] positions
        public static void Draw(Matrix matrix, GameTime gameTime)
        {
            Game1._spriteBatch.Begin(transformMatrix: matrix); //

            //BACKGROUND
            Game1._spriteBatch.Draw(Game1.atlas, new Vector2(0, 0), new Rectangle(1800, 0, 1800, 3600), Color.Purple, 0f,
                Vector2.Zero, 1f, SpriteEffects.None, 0f);
            //BULLETS
            for (int i = 0; i < Game1.controller.bullets.Count; i++)
            {
                Vector2 tempPos = Game1.controller.bullets[i].position;

                if(Lives.biggerBulletCount == 1)
                    Game1._spriteBatch.Draw(Game1.atlas, tempPos, new Rectangle(1430, 214, 225, 225), Color.White, 0f,
                    new Vector2(225 / 2 + 20, 225 / 2), 0.075f, SpriteEffects.None, 0f);
                else if(Lives.biggerBulletCount == 2)
                    Game1._spriteBatch.Draw(Game1.atlas, tempPos, new Rectangle(1430, 214, 225, 225), Color.White, 0f,
                    new Vector2(225 / 2 + 20, 225 / 2), 0.11f, SpriteEffects.None, 0f);
                else
                    Game1._spriteBatch.Draw(Game1.atlas, tempPos, new Rectangle(1430, 214, 225, 225), Color.White, 0f,
                    new Vector2(225 / 2 + 20, 225 / 2), 0.15f, SpriteEffects.None, 0f);

            }
            //SHIELD

            if (Lives.lives == 3) shieldColor = Color.White;
            if (Lives.lives == 2) shieldColor = Color.Yellow;
            if (Lives.lives == 1) shieldColor = Color.Green;



            Game1._spriteBatch.Draw(Game1.atlas, Game1.shieldPosition, new Rectangle(770, 560, 1000, 1000), shieldColor, 0f,
                new Vector2(1000 / 2 + 15, 1000 / 2), 2f, SpriteEffects.None, 0f);
            //GUN
            if (Lives.moreGunsCount == 1)
                Game1._spriteBatch.Draw(Game1.atlas, new Vector2(Game1.gunPosition.X, Game1.gunPosition.Y), new Rectangle(1080, 0, 150, 260), Color.White, Game1.gunRotation,
                new Vector2(150 / 2, 260), 0.3f, SpriteEffects.None, 0f);
            else if(Lives.moreGunsCount == 2)
            {
                Game1._spriteBatch.Draw(Game1.atlas, new Vector2(Game1.gunPosition.X, Game1.gunPosition.Y), new Rectangle(1080, 0, 150, 260), Color.White, Game1.gunRotation + 0.1f,
                new Vector2(150 / 2, 260), 0.3f, SpriteEffects.None, 0f);

                Game1._spriteBatch.Draw(Game1.atlas, new Vector2(Game1.gunPosition.X, Game1.gunPosition.Y), new Rectangle(1080, 0, 150, 260), Color.White, Game1.gunRotation - 0.1f,
                new Vector2(150 / 2, 260), 0.3f, SpriteEffects.None, 0f);
            }   
            else
            {
                Game1._spriteBatch.Draw(Game1.atlas, new Vector2(Game1.gunPosition.X, Game1.gunPosition.Y), new Rectangle(1080, 0, 150, 260), Color.White, Game1.gunRotation,
                new Vector2(150 / 2, 260), 0.3f, SpriteEffects.None, 0f);

                Game1._spriteBatch.Draw(Game1.atlas, new Vector2(Game1.gunPosition.X, Game1.gunPosition.Y), new Rectangle(1080, 0, 150, 260), Color.White, Game1.gunRotation + 0.2f,
                new Vector2(150 / 2, 260), 0.3f, SpriteEffects.None, 0f);

                Game1._spriteBatch.Draw(Game1.atlas, new Vector2(Game1.gunPosition.X, Game1.gunPosition.Y), new Rectangle(1080, 0, 150, 260), Color.White, Game1.gunRotation - 0.2f,
                new Vector2(150 / 2, 260), 0.3f, SpriteEffects.None, 0f);
            }     
            //TORRET
            Game1._spriteBatch.Draw(Game1.atlas, Game1.torretPosition, new Rectangle(12, 20, 891, 589), Color.White, 0f,
                new Vector2(891 / 2, 589 / 2), 0.25f, SpriteEffects.None, 0f);
            //ENEMY
            foreach (Enemy en in Controller.enemies)
            {
                if (en.GetType() == typeof(YellowEnemy))
                {
                    rectangleToDraw = new Rectangle(0, 700, 412, 412);
                    enemyScale = 0.5f;
                    enemyRotation = en.rotation;
                    origin = new Vector2(412 / 2, 412 / 2);

                } else if (en.GetType() == typeof(BlueEnemy))
                {
                    rectangleToDraw = en.animate(new Rectangle(0, 1667, 625, 450), new Rectangle(0, 1137, 625, 450));
                    enemyScale = 0.5f;
                    enemyRotation = 0;
                    origin = new Vector2(625 / 2 +20, 450 / 2);
                } else
                {
                    rectangleToDraw = en.animate(new Rectangle(0, 2845, 390, 680), new Rectangle(0, 2125, 390, 680));
                    enemyScale = 0.2f;
                    enemyRotation = 0;
                    origin = new Vector2(390 / 2, 680 / 2);
                }
                Game1._spriteBatch.Draw(Game1.atlas, en.position, rectangleToDraw, en.color, enemyRotation,
                origin, enemyScale, SpriteEffects.None, 0f);
            }
            //GIFT
            if (Gameplay.giftExists && Gameplay.gift.isOn)
            {
                if (Gameplay.gift.isHealth)
                {
                    Game1._spriteBatch.Draw(Game1.atlas, Gameplay.gift.position, new Rectangle(470, 2790, 280, 280), Color.White, 0,
                        new Vector2(280 / 2, 280 / 2), 0.5f, SpriteEffects.None, 0f);
                }
                else if (Gameplay.gift.moreGuns)
                {
                    Game1._spriteBatch.Draw(Game1.atlas, Gameplay.gift.position, new Rectangle(470, 2150, 280, 280), Color.Magenta, 0,
                        new Vector2(280 / 2, 280 / 2), 0.5f, SpriteEffects.None, 0f);
                }
                else if (Gameplay.gift.biggerBullet)
                {
                    Game1._spriteBatch.Draw(Game1.atlas, Gameplay.gift.position, new Rectangle(470, 2150, 280, 280), Color.MonoGameOrange, 0,
                        new Vector2(280 / 2, 280 / 2), 0.5f, SpriteEffects.None, 0f); //monogame orange
                }
                else
                {
                    Game1._spriteBatch.Draw(Game1.atlas, Gameplay.gift.position, new Rectangle(470, 2150, 280, 280), Color.White, 0,
                        new Vector2(280 / 2, 280 / 2), 0.5f, SpriteEffects.None, 0f);
                }
            }

            GameState.score.Draw(Game1._spriteBatch);

            //_spriteBatch.Draw(targetSprite, new Vector2(targetPosition.X - targetRadius, targetPosition.Y - targetRadius), Color.White);
            //_spriteBatch.DrawString(gameFont, "Score: " + score.ToString(), new Vector2(0, 0), Color.White);

            if (Lives.lives == 0)
            {
                Game1._spriteBatch.DrawString(Score.scorefont, "GAME OVER", new Vector2(250, 500), Color.White, 0, new Vector2(0, 0), (float)6.0, 0, 0);
                //Game1 game = new Game1();
                //game.Reset();
                //_game.ChangeState(new DeathState(_game, _graphicsDevice, _content));
            }
            Game1._spriteBatch.End();
            
        }
    }
}
