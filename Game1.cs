using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Mono_Summative_Assignment___Breakout_Game
{
    enum Screen
    {
        Intro,
        Game,
        GoodEnd,
        BadEnd
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D paddleTexture;
        Texture2D ballTexture;

        Texture2D introBackground;
        Texture2D galaxyBackground;
        Texture2D goodBackground;
        Texture2D badBackground;

        Rectangle ballRect;
        Rectangle brickRect;
        Rectangle paddleRect;
        Rectangle window;

        Paddle paddle;
        Ball ball;

        List<Brick> brickPlacer;
        List<Texture2D> brickTextures;

        SpriteFont textFont;

        KeyboardState keyboardState;
        Screen screenState;

        //Things to do
        //Make a Ball Class and give it all of its functions


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            screenState = Screen.Game;
            paddleRect = new Rectangle(0, 0, 25, 25);
            brickPlacer = new List<Brick>();
            window = new Rectangle(0, 0, 800, 500);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            brickTextures = new List<Texture2D>();

            base.Initialize();

            for (int x = 0; x < window.Width; x += 40)
                for (int y = 0; y < (window.Height - 250); y += 25)
                    brickPlacer.Add(new Brick(brickTextures, new Rectangle(x, y, 39, 24), Color.PaleTurquoise));
            paddle = new Paddle(paddleTexture, new Rectangle(350, 450, 100, 20));
            ball = new Ball(ballTexture, new Rectangle(385, 375, 25, 25));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            paddleTexture = Content.Load<Texture2D>("Images/paddle");
            ballTexture = Content.Load<Texture2D>("Images/marble");
            brickTextures.Add(Content.Load<Texture2D>("Images/crystal_brick"));

            textFont = Content.Load<SpriteFont>("Fonts/TextFont");

            galaxyBackground = Content.Load<Texture2D>("Images/purple_galaxy");
            introBackground = Content.Load<Texture2D>("Images/intro_background");
            goodBackground = Content.Load<Texture2D>("Images/good_end_background");
            badBackground = Content.Load<Texture2D>("Images/bad_end_background");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            keyboardState = Keyboard.GetState();
            paddle.Update(keyboardState);
            ball.Update(_graphics, paddle.Rect, brickPlacer);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screenState == Screen.Intro)
            {
                _spriteBatch.Draw(introBackground, window, Color.White);
                _spriteBatch.DrawString(textFont, "Breakout", new Vector2(400, 10), Color.Black);
            }
            else if (screenState == Screen.Game)
            {
                _spriteBatch.Draw(galaxyBackground, window, Color.White);
                foreach (Brick brick in brickPlacer)
                    brick.Draw(_spriteBatch);
                paddle.Draw(_spriteBatch);
                ball.Draw(_spriteBatch);
            }
            else if (screenState == Screen.GoodEnd)
            {
                _spriteBatch.Draw(goodBackground, window, Color.White);
            }
            else
            {
                _spriteBatch.Draw(badBackground, window, Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
