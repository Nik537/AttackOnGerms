using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttackOnGerms.States;
using Component = AttackOnGerms.States.Component;

namespace AttackOnGerms.Controls
{
    public class Button : Component
    {

        #region Fields

        /*foreach (TouchLocation tl in tc)
        {
            if (tl.State == TouchLocationState.Moved)
            {
                float verLength = gunPosition.Y - tl.Position.Y;
                float horLength = tl.Position.X - gunPosition.X;
                gunRotation = (float) Math.Atan(horLength / verLength);
            }

        if (touchCollection.Count > 0)
        {
            //Only Fire Select Once it's been released
            if (touchCollection[0].State == TouchLocationState.Moved || touchCollection[0].State == TouchLocationState.Pressed)
            {
                Console.WriteLine(touchCollection[0].Position);
            {
        }

        }*/
        private SpriteFont _font;
        //private bool _isHovering;
        private Texture2D _texture;
        #endregion

        #region Properties

        public EventHandler Click;

        public bool Clicked { get; private set; }

        public static float Layer { get; set; }

        public Vector2 Origin
        {
            get
            {
                return new Vector2(_texture.Width / 2, _texture.Height / 2);
            }
        }

        public Color PenColor { get; set; }
        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X - (int)Origin.X -30, (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
            }
        }

        public String Text;
        #endregion

        #region Methods

        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;
        }

        public override void Draw(GameTime gametime, SpriteBatch spriteBatch)
        {
            var color = Color.White;

            spriteBatch.Draw(_texture, Position, null, color, 0f, Origin, 1f, SpriteEffects.None, Layer);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x -50, y-10), Color.White, 0f, new Vector2(0, 0), 3f, SpriteEffects.None, Layer + 0.01f);
            }
        }

        public override void Update(GameTime gameTime)
        {
            TouchCollection tc = TouchPanel.GetState();
            /*
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = false;
            */
            if (tc.Count > 0)
            {
                Vector2 t = Vector2.Transform(tc[0].Position, Game1.matrix2);
                if (Rectangle.Contains((int)t.X, (int)t.Y)) //(int)tc[0].Position.X, (int)tc[0].Position.Y)
                {
                    //if (tc[0].State == TouchLocationState.Released) //neded?
                    //{
                        Click?.Invoke(this, new EventArgs());
                        Clicked = true;
                    //}
                }
            }

            #endregion

        }

    }
}
