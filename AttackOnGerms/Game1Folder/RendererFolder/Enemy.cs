using System;
using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

namespace AttackOnGerms.Game1Folder.RendererFolder
{
    public class Enemy
    {
        public Vector2 position = new Vector2(200, -200);
        public float rotation = 0;
        public int speed = 60;
        public int hp = 100;
        public bool dropsGift;
        public int radius;
        public static int enemyCount;
        public Color color;
        public Boolean dead;
        public int worth;

        virtual public void enemyUpdate(GameTime gameTime)
        {
            //float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //position.Y += speed * dt;
        }

        public void enemyDeath()
        {

        }
    }

    public class YellowEnemy : Enemy
    {
        public YellowEnemy()
        {
            Random rand = new Random();
            position = new Vector2(rand.Next(100, 1080-100), -200);
            speed = 40;
            hp = 50;
            dropsGift = true;
            radius = 206;
            rotation = 0;
            color = Color.White;
            worth = 10;
            dead = false;
        }

        public override void enemyUpdate(GameTime gameTime)
        {
            
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (hp < 15)
            {
                position.Y += 80 * dt;
                rotation += (float)0.06;
            }
            else
            {
                position.Y += speed * dt;
                rotation += (float)0.03;
            }
            
            
        }
    }
    public class BlueEnemy : Enemy
    {
        public BlueEnemy()
        {
            Random rand = new Random();
            position = new Vector2(rand.Next(100, 1080 - 200), -200);
            speed = 90;
            hp = 25;
            dropsGift = false;
            radius = 206;
            rotation = 0;
            color = Color.White;
            worth = 5;
            dead = false;
        }

        public override void enemyUpdate(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += speed * dt;
            rotation += (float)0.04;
        }
    }
    public class GreenEnemy : Enemy
    {
        public GreenEnemy()
        {
            Random rand = new Random();
            position = new Vector2(rand.Next(300, 1080 - 300), -200);
            speed = 160;
            hp = 5;
            dropsGift = false;
            radius = 206;
            rotation = 0;
            color = Color.White;
            worth = 1;
            dead = false;
        }

        public override void enemyUpdate(GameTime gameTime)
        {

            float scaleX = (float)Math.Sin(-1 * Game1.gunRotation);
            //float scaleY = (float)Math.Cos(-1 * Game1.gunRotation);
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (position.X < 1050 && position.X > 50)
            {
                System.Console.WriteLine(Game1.gunRotation);
                if (Game1.gunRotation < 0) position.X += speed * dt;
                else if (Game1.gunRotation == 0) position.X = position.X;
                else position.X -= speed * dt;
            }
            position.Y += speed * dt;
            rotation += (float)0.04;
        }
    }
}
