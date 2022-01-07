using System;
using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

namespace AttackOnGerms.Game1Folder.HumanPlayerFolder
{
    public class Controls
    {  
        public static float MoveGun(Vector2 gunPosition, float gunRotation)
        {
            TouchCollection tc = TouchPanel.GetState();

            foreach (TouchLocation tl in tc)
            {
                if (tl.State == TouchLocationState.Moved)
                {
                    Vector2 t = Vector2.Transform(tl.Position, Game1.matrix2);
                    float verLength = gunPosition.Y - t.Y;
                    float horLength = t.X - gunPosition.X;
                    gunRotation = (float)Math.Atan(horLength / verLength);
                }

            }
            return gunRotation;
        }
        
    }
}
