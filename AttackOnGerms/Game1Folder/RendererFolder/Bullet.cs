using System;
using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

namespace AttackOnGerms.Game1Folder.RendererFolder
{
    public class Bullet
    {

        public Vector2 position = new Vector2(20000, 20000);
        public int speed = 460;
        public float velocityX;
        public float velocityY;
        public Boolean colidet;
        //Ko se nardi nov bulet mu to določiš
        // bullets size 100 recimo in pol se povozjo tastari


        public Bullet(Vector2 gunPosition)
        {
            this.position = new Vector2(gunPosition.X, gunPosition.Y + 26);
            this.colidet = false;
        }

        public Bullet(int newSpeed)
        {
            this.speed = newSpeed;
            this.colidet = false;
        }

        public Bullet(Vector2 gunPosition, int newSpeed, double velocityX, double velocityY)
        {
            this.position = new Vector2(gunPosition.X, gunPosition.Y);
            this.speed = newSpeed;
            this.velocityX = (float)velocityX;
            this.velocityY = (float)velocityY;
            this.colidet = false;
        }

        public void bulletUpdate(GameTime gameTime, float gunRotation) //gunRotation med -1 in 1
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            var velocity = speed * dt;
            
            position.Y -= velocity * velocityY;
            position.X -= velocity * velocityX;
          
        }
        
    }
}
