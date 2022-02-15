using System;
using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

using AttackOnGerms.Game1Folder.HumanPlayerFolder;
using AttackOnGerms.States;

namespace AttackOnGerms.Game1Folder.RendererFolder
{
    public class Gift
    {
        public Vector2 position;
        public bool isHealth;
        public bool isOn;

        public bool biggerBullet;
        public bool moreGuns;

        //public static int biggerBulletCount = 1;
        //public static int moreGunsCount = 1;
        //public int biggerBulletCount = 1;
        //public int moreGunsCount = 1;

        int num;
        Random rnd;

        public Gift(Vector2 position)
        {
            this.position = position;
            if (Lives.lives < 3) {
                isHealth = true;
                biggerBullet = false;
                moreGuns = false;
            }
            else
            {
                isHealth = false;
                rnd = new Random();
                num = rnd.Next(1, 13);  // creates a number between 1 and 12
                //int dice = rnd.Next(1, 7);
                if (num % 5 == 0 && Lives.biggerBulletCount < 3)
                {
                    biggerBullet = true;
                    //Lives.biggerBulletCount++; //zakaj to povzroci da je samo en special
                    moreGuns = false;
                }
                else if (num % 9 == 0 && Lives.moreGunsCount < 3)
                {
                    moreGuns = true;
                    //Lives.moreGunsCount++;
                    biggerBullet = false;
                }

            }
            isOn = true;
        }
    }
}
