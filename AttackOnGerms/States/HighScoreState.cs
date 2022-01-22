using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using AttackOnGerms.Controls;
using AttackOnGerms.States;

using MonoGame;
using System.ComponentModel;

using System.Text.Json.Serialization;


namespace AttackOnGerms.States
{
    public class HighscoresState : State
    {
        private List<Component> components;

        private SpriteFont font;

        private Texture2D menuBackGroundTexture;

        public static int highScore;

        public HighscoresState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("button4");
            var buttonFont = _content.Load<SpriteFont>("ButtonFonts/Font");
            menuBackGroundTexture = _content.Load<Texture2D>("ozadje");

            var replayButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(280, 1600),
                Text = "   Play",
            };

            replayButton.Click += Button_Replay_Click;

            var mainMenuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(800, 1600),
                Text = " Main Menu",
            };

            mainMenuButton.Click += Button_MainMenu_Click;

            components = new List<Component>()
            {
                replayButton,
                mainMenuButton,
            };
        }

        public override void LoadContent()
        {
            font = _content.Load<SpriteFont>("ButtonFonts/Font");
        }


        private void Button_Replay_Click(object sender, EventArgs args)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void Button_MainMenu_Click(object sender, EventArgs args)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        public override void Update(GameTime gameTime)
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Button_MainMenu_Click(this, new EventArgs());

            foreach (var component in components)
                component.Update(gameTime);
        }

       

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: Game1.matrix);

            spriteBatch.Draw(menuBackGroundTexture, new Vector2(0, 0), Color.Purple);

            foreach (var component in components)
                component.Draw(gameTime, spriteBatch);

            var layer = Button.Layer;
            spriteBatch.DrawString(font, "Highscore: " + Game1.Load(), new Vector2(300, 300), Color.White, 0f, new Vector2(0, 0), 4f, SpriteEffects.None, layer + 0.01f);

            spriteBatch.End();
        }
    }
}
