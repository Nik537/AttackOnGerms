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
using AttackOnGerms;
using Android.Util;
using Microsoft.Xna.Framework.Input.Touch;
using AttackOnGerms.Game1Folder;
using AttackOnGerms.Game1Folder.RendererFolder;
using AttackOnGerms.Game1Folder.HumanPlayerFolder;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace AttackOnGerms.States
{
    public class GameState : State
    {
        private SpriteFont font;

        //private List<Sprite> sprites;

        private int playerCount = 0;

        private float timer;

        public static int screenWidth = 1920;

        public static int screenHeight = 1080;

        public static Random random;

        //public static Score score;

        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;

        public static Texture2D atlas;

        public static Vector2 shieldPosition;
        public static Vector2 gunPosition;
        public static Vector2 torretPosition;
        //public static Vector2 yellowEnemyPosition;

        public static float scaleX;
        public static float scaleY;

        public static float gunRotation;

        //public static GameWindow;
        public static Matrix matrix;
        //public static Enemy yellowEnemy = new YellowEnemy(new Vector2(200, -200));
        public static Enemy blueEnemy = new Enemy();
        public static Enemy greenEnemy = new Enemy();
        public static Bullet bullet;

        public static Controller controller = new Controller();
        private GameTime gameTime;

        public static Song song;
        public static SoundEffect shootSound;
        public static SoundEffect enemyExplosionSound;
        public static SoundEffect shieldExplosionSound;
        public static SoundEffect powerUpSound;

        public static Score score;

        

        public GameState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
            : base(game, graphicsDevice, content)
        {
            score = new Score(MenuState.buttonFont);
        }

        public override void LoadContent()
        {
            Gameplay.loadGameContent(gameTime);

            //MediaPlayer.Play(Game1.song);

        }

        /*
        public override void OnBackPressed()
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }
        */


        public override void Update(GameTime gameTime)
        {
            Gameplay.updateGame(gameTime);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
            }
            //base.Update(gameTime);

        }

       

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            matrix = Matrix.CreateScale(Game1.scaleX, Game1.scaleY, 1.0f);
            Gameplay.drawGame(gameTime, matrix);
        }
    }
}
