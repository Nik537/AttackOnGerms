using System;
using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using AttackOnGerms.Game1Folder.RendererFolder;
using AttackOnGerms.Game1Folder.HumanPlayerFolder;
using Microsoft.Xna.Framework.Audio;

namespace AttackOnGerms.Game1Folder.RendererFolder
{
    public class Controller
    {

        public List<Bullet> bullets = new List<Bullet>(100);
        public static List<Enemy> enemies = new List<Enemy>(0);

        public static double timer = 2D;
        public static float rofUpgrade = 0.2F;

        public static bool first = true;

        public static double yellowEnemyTimer = 24D; //24
        public static double greenEnemyTimer = 4D; //4
        public static double blueEnemyTimer = 12D; //12

        public static double maxYellowTime = 24D; //24
        public static double maxGreenTime = 4D;
        public static double maxBlueTime = 12D;

        public void controllerUpdate(GameTime gameTime, Vector2 gunPosition, float gunRotation, SoundEffect soundEffect)
        {
            timer -= gameTime.ElapsedGameTime.TotalSeconds + rofUpgrade;
            yellowEnemyTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            greenEnemyTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            blueEnemyTimer -= gameTime.ElapsedGameTime.TotalSeconds;

            if (first)
            {
                enemies.Add(new GreenEnemy());
                enemies.Add(new BlueEnemy());
                Gameplay.timer = 0d;
                first = false;
            }

            if (timer <= 0) //BULLETS
            {
                soundEffect.Play();
                if(Lives.moreGunsCount == 1)
                {
                    var scaleX = Math.Sin(-1 * gunRotation);
                    var scaleY = Math.Cos(-1 * gunRotation);
                    bullets.Add(new Bullet(gunPosition, 1950, scaleX, scaleY));
                }
                else if (Lives.moreGunsCount == 2)
                {
                    var scaleX = Math.Sin(-1 * (gunRotation + 0.1f));
                    var scaleY = Math.Cos(-1 * (gunRotation + 0.1f));
                    bullets.Add(new Bullet(gunPosition, 1950, scaleX, scaleY));

                    var scaleX2 = Math.Sin(-1 * (gunRotation - 0.1f));
                    var scaleY2 = Math.Cos(-1 * (gunRotation - 0.1f));
                    bullets.Add(new Bullet(gunPosition, 1950, scaleX2, scaleY2));
                }
                else
                {
                    var scaleX0 = Math.Sin(-1 * (gunRotation + 0.2f));
                    var scaleY0 = Math.Cos(-1 * (gunRotation + 0.2f));
                    bullets.Add(new Bullet(gunPosition, 1950, scaleX0, scaleY0));

                    var scaleX = Math.Sin(-1 * gunRotation);
                    var scaleY = Math.Cos(-1 * gunRotation);
                    bullets.Add(new Bullet(gunPosition, 1950, scaleX, scaleY));

                    var scaleX2 = Math.Sin(-1 * (gunRotation - 0.2f));
                    var scaleY2 = Math.Cos(-1 * (gunRotation - 0.2f));
                    bullets.Add(new Bullet(gunPosition, 1950, scaleX2, scaleY2));
                }


                timer = 3D;
                
            }
            
            if (yellowEnemyTimer <= 0) //
            {
                enemies.Add(new YellowEnemy());
                //yellowEnemyTimer = 12D;
                yellowEnemyTimer = maxYellowTime;
                if (maxYellowTime > 4)
                {
                    maxYellowTime -= 0.05;
                }
            }

            if (greenEnemyTimer <= 0) //
            {
                enemies.Add(new GreenEnemy());
                //greenEnemyTimer = 2D;
                greenEnemyTimer = maxGreenTime;
                if (maxGreenTime > 1)
                {
                    maxGreenTime -= 0.025;
                }
            }

            if (blueEnemyTimer <= 0) //
            {
                enemies.Add(new BlueEnemy());
                //blueEnemyTimer = 6D;
                blueEnemyTimer = maxBlueTime;
                if (maxBlueTime > 1)
                {
                    maxBlueTime -= 0.2;
                }

            }
        }
    }
}
