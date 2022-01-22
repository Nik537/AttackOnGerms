using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AttackOnGerms.Game1Folder.RendererFolder;
using AttackOnGerms.Game1Folder.HumanPlayerFolder;
using AttackOnGerms.States;

namespace AttackOnGerms.Game1Folder
{
    public class Gameplay
    {
        public static double timer = 1D;

        public static float rofUpgrade = 0.1F;

        public static Gift gift;

        public static bool giftExists;

        public static void loadGameContent(GameTime gameTime)
        {
            Game1.shieldPosition = new Vector2(
                535,
                1920); 

            Game1.gunPosition = new Vector2(
                540,
                1920 - 80);

            Game1.torretPosition = new Vector2(
                540,
                1920 - 50);

            giftExists = false;
            //Controller.enemies.Capacity += 1;
            
            /*
            Enemy yellowEnemy = new YellowEnemy(new Vector2(200, -200));
            Enemy greenEnemy = new GreenEnemy(new Vector2(900, -200));
            Enemy blueEnemy = new BlueEnemy(new Vector2(500, -200));
            Controller.enemies.Add(yellowEnemy);
            Controller.enemies.Add(greenEnemy);
            Controller.enemies.Add(blueEnemy);
            */
        }

        public static void updateGame(GameTime gameTime)
        {
            
            for (int j = 0; j < Controller.enemies.Count; j++)
            {

                //Vector2 v = Game1.controller.bullets[i].position - Game1.yellowEnemy.position;
                double distance = Vector2.Distance(Game1.shieldPosition, Controller.enemies[j].position);//Math.Sqrt(v.X * v.X + v.Y * v.Y);
                if (distance <= (1020))
                { //35 + 206
                    Game1.shieldExplosionSound.Play();
                    Controller.enemies[j].hp -= 1000;
                    Controller.enemies[j].color = Color.Red;
                    Lives.lives -= 1;
                }
            }
            Game1.gunRotation = HumanPlayerFolder.Controls.MoveGun(Game1.gunPosition,  Game1.gunRotation);
            for (int j = 0; j < Controller.enemies.Count; j++)
            {
                Controller.enemies[j].enemyUpdate(gameTime);
            }
            //bulletUpdate(gameTime, gunRotation);

            Game1.controller.controllerUpdate(gameTime, Game1.gunPosition, Game1.gunRotation, Game1.shootSound);
            for (int i = 0; i < Game1.controller.bullets.Count; i++) 
            {
                Game1.controller.bullets[i].bulletUpdate(gameTime, Game1.gunRotation);
                for (int j = 0; j < Controller.enemies.Count; j++)
                {
                   
                    //Vector2 v = Game1.controller.bullets[i].position - Game1.yellowEnemy.position;
                    double distance = Vector2.Distance(Game1.controller.bullets[i].position, Controller.enemies[j].position);//Math.Sqrt(v.X * v.X + v.Y * v.Y);
                    if (distance <= (120)) { //35 + 206
                        Game1.controller.bullets[i].colidet = true;
                        Controller.enemies[j].hp -= 1;
                        Controller.enemies[j].color = Color.Red;
                        Score.score += 1;
                    }
                    timer -= gameTime.ElapsedGameTime.TotalSeconds + rofUpgrade;
                    if (Controller.enemies[j].hp <= 0)
                    {
                        Game1.enemyExplosionSound.Play();

                        if (Controller.enemies[j].dropsGift)
                        {
                            gift = new Gift(Controller.enemies[j].position);
                            giftExists = true;
                        }
                        

                        Controller.enemies[j].dead = true;


                    }
                    if (timer <= 0) //
                    {
                        Controller.enemies[j].color = Color.White;
                        timer = 5D;
                    }
                }
                
                
            }
            Controller.enemies.RemoveAll(e => e.dead);
            //Controller.enemies.Capacity -= 1;
            Game1.controller.bullets.RemoveAll(e => e.colidet);
            //Controller.bullets.Capacity -= 1;

        }

        public static void drawGame(GameTime gameTime, Matrix matrix)
        {
            //_spriteBatch, atlas, gunRotation, controller, positions
            Renderer.Draw(matrix, gameTime);
        }

    }
}
