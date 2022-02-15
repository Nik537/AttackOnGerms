using System;
using Android.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;
using AttackOnGerms.Game1Folder;
using AttackOnGerms.Game1Folder.RendererFolder;
using AttackOnGerms.Game1Folder.HumanPlayerFolder;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using AttackOnGerms.States;

using System.Text.Json;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;

//using (var stream = Game.Activity.Assets.Open(document.json));

namespace AttackOnGerms
{
    public class Game1 : Game
    {
        
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
        public static Matrix matrix2;
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

        private State _currentState;
        private State _nextState;

        

        //public static Texture2D blueEnemytex;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
           
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            _graphics.PreferredBackBufferWidth = 9;
            _graphics.PreferredBackBufferHeight = 16;

            _graphics.ApplyChanges();

            scaleX = (float)GraphicsDevice.Viewport.Width / 1080;
            scaleY = (float)GraphicsDevice.Viewport.Height / 1920;
            matrix = Matrix.CreateScale(scaleX, scaleY, 1.0f);


            matrix2 = Matrix.Invert(matrix);

            base.Initialize();
        }

        /*
        public static Texture2D CreateTexture(Texture2D src, Rectangle rect)
        {
            //Texture2D tex = new Texture2D(GraphicsDevice, rect.Width, rect.Height);
            Texture2D tex = blueEnemytex; 
            int count = rect.Width * rect.Height;
            Color[] data = new Color[count];
            src.GetData(0, rect, data, 0, count);
            tex.SetData(data);
            return blueEnemytex;
        }
        */

        protected override void LoadContent()
        {

            //blueEnemytex = new Texture2D(GraphicsDevice, 644, 1000);
            atlas = Content.Load<Texture2D>("Atlas4");
            //song = Content.Load<Song>("Song");

            song = Content.Load<Song>("Song");

            MediaPlayer.IsRepeating = true;

            MediaPlayer.Play(song);

            shootSound = Content.Load<SoundEffect>("Laser_Shoot19");
            enemyExplosionSound = Content.Load<SoundEffect>("Explosion18enemy");
            shieldExplosionSound = Content.Load<SoundEffect>("Explosion23shield");
            powerUpSound = Content.Load<SoundEffect>("Powerup3");

            

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            if (Int32.Parse(Load()) == 0)
            {
                _currentState = new IntroState(this, GraphicsDevice, Content);
                
            }
            else _currentState = new MenuState(this, GraphicsDevice, Content);

            _currentState.LoadContent();
            _nextState = null;
        }

        protected override void Update(GameTime gameTime)
        {
            {
                if (_nextState != null)
                {
                    _currentState = _nextState;
                    _currentState.LoadContent();

                    _nextState = null;
                }
                _currentState.Update(gameTime);
                //_currentState.PostUpdate(gameTime);
            }
            base.Update(gameTime);


        }

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        protected override void Draw(GameTime gameTime) //16:9
        {
            //createOrtographic camera

            GraphicsDevice.Clear(Color.Black);

            _currentState.Draw(gameTime, _spriteBatch);


            //var scl = (float) Math.Sqrt((GraphicsDevice.Viewport.Bounds.Width/1080)^2 + (GraphicsDevice.Viewport.Bounds.Height/1920)^2);
            base.Draw(gameTime);
        }
        public static void Save()
        {
            IsolatedStorageFile savegameStorage = IsolatedStorageFile.GetUserStoreForApplication();
            StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream("HighScoreFile.txt", FileMode.OpenOrCreate, savegameStorage));
            writer.WriteLine(HighscoresState.highScore);
            writer.Close();
        }

        public static String Load()
        {
            IsolatedStorageFile savegameStorage = IsolatedStorageFile.GetUserStoreForApplication();
            try
            {
                StreamReader reader = new StreamReader(new IsolatedStorageFileStream("HighScoreFile.txt", FileMode.Open, savegameStorage));
                String content = reader.ReadToEnd();
                reader.Close();
                return content;
            }
            catch
            {
                return "0";
            }
        }

        
    }
}