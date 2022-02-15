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
        //public AnimatedSprite anim;

        //player animation
        public float FrameIndex { get; set; } //pick one of the animation frames from a list
        public float AnimationSpeed { get; set; }//how fast the animations updates
        //public string EnemyStatus { get; set; } //pove a se player premika al stoji, skace itd

        virtual public void enemyUpdate(GameTime gameTime)
        {
            //float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            //position.Y += speed * dt;
        }

        public void enemyDeath()
        {

        }

        public Rectangle animate(Rectangle sprite1, Rectangle sprite2)
        {
            List<Rectangle> animation = new List<Rectangle>();
            animation.Add(sprite1);
            animation.Add(sprite2);

            //loop over the frame index
            FrameIndex += AnimationSpeed;
            if (FrameIndex >= animation.Count)
                FrameIndex = 0f;


            return animation[(int)FrameIndex];
        }

    }

    public class YellowEnemy : Enemy
    {
        public YellowEnemy()
        {
            Random rand = new Random();
            position = new Vector2(rand.Next(100, 1080-100), -80);
            speed = 40;
            hp = 26; //26
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
            position = new Vector2(rand.Next(100, 1080 - 200), -70);
            speed = 90;
            hp = 11;
            dropsGift = false;
            radius = 206;
            rotation = 0;
            color = Color.White;
            worth = 5;
            dead = false;

            FrameIndex = 0f;
            //EnemyStatus = "idle1";
            AnimationSpeed = 0.10f;

        }

        public Rectangle animate(Rectangle sprite1, Rectangle sprite2)
        {
            List<Rectangle> animation = new List<Rectangle>();
            animation.Add(sprite1);
            animation.Add(sprite2);

            //loop over the frame index
            FrameIndex += AnimationSpeed;
            if (FrameIndex >= animation.Count)
                FrameIndex = 0f;


            return animation[(int)FrameIndex];
        }

        public override void enemyUpdate(GameTime gameTime)
        {
           
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position.Y += speed * dt;
            rotation += (float)0.04;
            //animate();
        }
    }
    public class GreenEnemy : Enemy
    {
        public GreenEnemy()
        {
            Random rand = new Random();
            position = new Vector2(rand.Next(50, 1080 - 50), -50);
            speed = 115;
            hp = 5;
            dropsGift = false;
            radius = 206;
            rotation = 0;
            color = Color.White;
            worth = 1;
            dead = false;

            AnimationSpeed = 0.10f;
        }

        public Rectangle animate(Rectangle sprite1, Rectangle sprite2)
        {
            List<Rectangle> animation = new List<Rectangle>();
            animation.Add(sprite1);
            animation.Add(sprite2);

            //loop over the frame index
            FrameIndex += AnimationSpeed;
            if (FrameIndex >= animation.Count)
                FrameIndex = 0f;


            return animation[(int)FrameIndex];
        }

        public override void enemyUpdate(GameTime gameTime)
        {

            float scaleX = (float)Math.Sin(-1 * Game1.gunRotation);
            //float scaleY = (float)Math.Cos(-1 * Game1.gunRotation);
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (position.X < 1030 && position.X > 50)
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
