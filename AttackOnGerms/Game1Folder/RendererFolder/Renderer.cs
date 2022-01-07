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
                Game1._spriteBatch.Draw(Game1.atlas, tempPos, new Rectangle(356, 1296, 70, 70), Color.White, 0f,
                new Vector2(70 / 2, 70 / 2), 0.25f, SpriteEffects.None, 0f);
            }
            //SHIELD
            
            if (Lives.lives == 3) shieldColor = Color.White;
            if (Lives.lives == 2) shieldColor = Color.Yellow;
            if (Lives.lives == 1) shieldColor = Color.Green;
            if (Lives.lives == 0) shieldColor = Color.Red;
            Game1._spriteBatch.Draw(Game1.atlas, Game1.shieldPosition, new Rectangle(770, 560, 1000, 1000), shieldColor, 0f,
                new Vector2(1000 / 2 +3, 1000 / 2), 2f, SpriteEffects.None, 0f);
            //GUN
            Game1._spriteBatch.Draw(Game1.atlas, Game1.gunPosition, new Rectangle(1080, 0, 150, 260), Color.White, Game1.gunRotation,
                new Vector2(150 / 2, 260), 0.3f, SpriteEffects.None, 0f);
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
                } else if (en.GetType() == typeof(BlueEnemy))
                {
                    //animeTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                    //if(animeTimer <= 0) rectangleToDraw = new Rectangle(0, 1143, 625, 450);
                    rectangleToDraw = new Rectangle(0, 1660, 625, 450);
                    
                    enemyScale = 0.5f;
                    enemyRotation = 0;
                } else
                {
                    rectangleToDraw = new Rectangle(0, 2120, 380, 680);
                    enemyScale = 0.2f;
                    enemyRotation = 0;
                }
                Game1._spriteBatch.Draw(Game1.atlas, en.position, rectangleToDraw, en.color, enemyRotation,
                new Vector2(412 / 2, 412 / 2), enemyScale, SpriteEffects.None, 0f);
            }


            GameState.score.Draw(Game1._spriteBatch);

            //_spriteBatch.Draw(targetSprite, new Vector2(targetPosition.X - targetRadius, targetPosition.Y - targetRadius), Color.White);
            //_spriteBatch.DrawString(gameFont, "Score: " + score.ToString(), new Vector2(0, 0), Color.White);
            Game1._spriteBatch.End();

            
        }
    }
}
