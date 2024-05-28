using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Time_and_Sound
{
    public class Game1 : Game
    {
       private SoundEffect explode;
        
        
        Texture2D bombTexture;
        SpriteFont timeFont;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        float seconds;
        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            seconds = 0;
            
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            explode = Content.Load<SoundEffect>("explosion");

            // TODO: use this.Content to load your game content here
            bombTexture = Content.Load<Texture2D>("bomb");
            timeFont = Content.Load<SpriteFont>("Time");
        }

        protected override void Update(GameTime gameTime)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
                seconds = 0f;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (seconds > 10)
                seconds = 0f;
            // TODO: Add your update logic here

            if (seconds >= 10)
            {
                explode.Play();
                seconds = 0f;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(bombTexture, new Rectangle (50,50, 700,400), Color.White);

            //_spriteBatch.DrawString(timeFont, "1:00", new Vector2(270, 200), Color.Black);


            _spriteBatch.DrawString(timeFont, seconds.ToString(), new Vector2(270, 200), Color.Black);
            seconds.ToString("00.0");






            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
