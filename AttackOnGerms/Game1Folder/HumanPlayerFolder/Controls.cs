using System;
using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;


using AttackOnGerms.Game1Folder.HumanPlayerFolder;
using AttackOnGerms.Game1Folder.RendererFolder;

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
                    if (Gameplay.giftExists && Gameplay.gift.isOn)
                    {
                        double distance = Vector2.Distance(t, Gameplay.gift.position);
                        if (distance <= (120))
                        {
                            if (Gameplay.gift.isHealth )
                            {
                                Lives.lives++;
                                Gameplay.gift.isOn = false;
                            } else
                            {
                                Controller.rofUpgrade += 0.01f;
                                Gameplay.gift.isOn = false;
                            }
                        }
                    }
                }

            }
            return gunRotation;
        }
        
    }
}
