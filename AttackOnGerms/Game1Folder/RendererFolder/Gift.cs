using System;
using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

using AttackOnGerms.Game1Folder.HumanPlayerFolder;

namespace AttackOnGerms.Game1Folder.RendererFolder
{
    public class Gift
    {
        public Vector2 position;
        public bool isHealth;
        public bool isOn;

        public Gift(Vector2 position)
        {
            this.position = position;
            if (Lives.lives < 3) isHealth = true;
            else isHealth = false;
            isOn = true;
        }
    }
}
