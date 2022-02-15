using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework.Input;
//using AttackOnGerms.Sprites;
//using AttackOnGerms.Models;
using AttackOnGerms.States;
using AttackOnGerms.Controls;
using MonoGame;
using System.ComponentModel;
namespace AttackOnGerms.States
{
    public class IntroState : State
    {
        private List<Component> components;
        private SpriteFont font;

        private Texture2D menuBackGroundTexture;
        public static SpriteFont buttonFont;

        public IntroState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("button4");
            buttonFont = _content.Load<SpriteFont>("ButtonFonts/Font");

            

            var mainMenuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(540, 1650),
                Text = "     OK",
            };

            mainMenuButton.Click += Button_HighScores_Clicked;

            

            components = new List<Component>()
            {

                mainMenuButton,
                
            };
        }

        public override void LoadContent()
        {
            font = _content.Load<SpriteFont>("ButtonFonts/Font");
            menuBackGroundTexture = _content.Load<Texture2D>("ozadje"); //ButtonFonts/background
        }

        

        private void Button_HighScores_Clicked(object sender, EventArgs args)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        

        public override void Update(GameTime gameTime)
        {
            foreach (var component in components)
                component.Update(gameTime);
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: Game1.matrix);

            spriteBatch.Draw(menuBackGroundTexture, new Vector2(0, 0), Color.Purple);

            Game1._spriteBatch.Draw(Game1.atlas, new Vector2(160, 50), new Rectangle(0, 2845, 390, 680), Color.White, 0,
                new Vector2(0, 0), 0.25f, SpriteEffects.None, 0f);

            Game1._spriteBatch.Draw(Game1.atlas, new Vector2(390, 60), new Rectangle(0, 1667, 625, 450), Color.White, 0,
                new Vector2(0, 0), 0.45f, SpriteEffects.None, 0f);

            Game1._spriteBatch.Draw(Game1.atlas, new Vector2(750, 50), new Rectangle(0, 700, 412, 412), Color.White, 0,
                new Vector2(0, 0), 0.5f, SpriteEffects.None, 0f);

            var layer = Button.Layer;
            spriteBatch.DrawString(font, "  Shoot the germs! \n\n\nProtect the cell wall\n as long as you can", new Vector2(280, 460), Color.White, 0f, new Vector2(0, 0), 4f, SpriteEffects.None, layer + 0.01f);


            Game1._spriteBatch.Draw(Game1.atlas, new Vector2(529, 1980), new Rectangle(770, 560, 1000, 1000), Color.White, 0f,
                new Vector2(1000 / 2 + 15, 1000 / 2), 2f, SpriteEffects.None, 0f);

            foreach (var component in components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}

