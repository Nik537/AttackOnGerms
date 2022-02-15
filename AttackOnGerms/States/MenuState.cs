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
    public class MenuState : State
    {
        private List<Component> components;

        private Texture2D menuBackGroundTexture;
        public static SpriteFont buttonFont;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
      : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("button4");
            buttonFont = _content.Load<SpriteFont>("ButtonFonts/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(540, 400),
                Text = "   Play",
            };

            newGameButton.Click += Button_NewGame_Click;

            var highScoresButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(540, 900),
                Text = "High Scores",
            };

            highScoresButton.Click += Button_HighScores_Clicked;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(540, 1400),
                Text = " Quit Game",
            };

            quitGameButton.Click += Button_Quit_Clicked;

            components = new List<Component>()
            {
                newGameButton,
                highScoresButton,
                quitGameButton,
            };
        }

        public override void LoadContent()
        {
            menuBackGroundTexture = _content.Load<Texture2D>("ozadje");//ButtonFonts/background
        }

        private void Button_NewGame_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void Button_HighScores_Clicked(object sender, EventArgs args)
        {
            _game.ChangeState(new HighscoresState(_game, _graphicsDevice, _content));
        }

        private void Button_Quit_Clicked(object sender, EventArgs args)
        {
            _game.Exit();
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

            


            foreach (var component in components)
                component.Draw(gameTime, spriteBatch);

            spriteBatch.End();
        }
    }
}
