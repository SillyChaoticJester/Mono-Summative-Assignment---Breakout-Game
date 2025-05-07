using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
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
        Rectangle window;

        Paddle paddle;
        Ball ball;

        List<Brick> brickPlacer;
        List<Texture2D> brickTextures;

        SpriteFont textFont;
        SpriteFont messageFont;

        KeyboardState keyboardState;
        Screen screenState;

        SoundEffect musicEffect;
        SoundEffect introEffect;
        SoundEffect goodEffect;
        SoundEffect badEffect;
        SoundEffectInstance musicEffectInstance;
        SoundEffectInstance introEffectInstance;
        SoundEffectInstance goodEffectInstance;
        SoundEffectInstance badEffectInstance;

        SoundEffect ouchEffect;
        SoundEffectInstance ouchEffectInstance;

        //Things to do
        //Make a Ball System


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            screenState = Screen.Intro;
            ballRect = new Rectangle(0, 465, 30, 30); 
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
            messageFont = Content.Load<SpriteFont>("Fonts/MessageFont");

            galaxyBackground = Content.Load<Texture2D>("Images/purple_galaxy");
            introBackground = Content.Load<Texture2D>("Images/intro_background");
            goodBackground = Content.Load<Texture2D>("Images/good_end_background");
            badBackground = Content.Load<Texture2D>("Images/bad_end_background");

            musicEffect = Content.Load<SoundEffect>("Sounds-Music/please_work");
            musicEffectInstance = musicEffect.CreateInstance();
            musicEffectInstance.IsLooped = true;

            introEffect = Content.Load<SoundEffect>("Sounds-Music/station");
            introEffectInstance = introEffect.CreateInstance();
            introEffectInstance.IsLooped = true;

            goodEffect = Content.Load<SoundEffect>("Sounds-Music/jaunt");
            goodEffectInstance = goodEffect.CreateInstance();
            goodEffectInstance.IsLooped = true;

            badEffect = Content.Load<SoundEffect>("Sounds-Music/notsohappymusic");
            badEffectInstance = badEffect.CreateInstance();
            badEffectInstance.IsLooped = true;

            ouchEffect = Content.Load<SoundEffect>("Sounds-Music/ouch");
            ouchEffectInstance = ouchEffect.CreateInstance();

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            keyboardState = Keyboard.GetState();

            if (screenState == Screen.Intro)
            {
                introEffectInstance.Play();
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    introEffectInstance.Stop();
                    screenState = Screen.Game;
                }
            }
            else if (screenState == Screen.Game)
            {
                paddle.Update(keyboardState);
                ball.Update(_graphics, paddle.Rect, brickPlacer, ouchEffectInstance);
                musicEffectInstance.Play();
                if (brickPlacer.Count == 0 && ball.Lives > 0)
                {
                    screenState = Screen.GoodEnd;
                    musicEffectInstance.Stop();
                }
                else if (ball.Lives == 0)
                {
                    screenState = Screen.BadEnd;
                    musicEffectInstance.Stop();
                }
            }
            else if (screenState == Screen.GoodEnd)
            {
                goodEffectInstance.Play();
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    goodEffectInstance.Stop();
                    Exit();
                }
            }
            else
            {
                badEffectInstance.Play();
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    badEffectInstance.Stop();
                    Exit();
                }
            }

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
                _spriteBatch.DrawString(textFont, "Breakout", new Vector2(275, 10), Color.Black);
                _spriteBatch.DrawString(messageFont, "Press ENTER to start.", new Vector2(275, 250), Color.Black);
                _spriteBatch.DrawString(messageFont, "Instructions:", new Vector2(345, 380), Color.Black);
                _spriteBatch.DrawString(messageFont, "Move the Paddle with A & D, you only have three lives.", new Vector2(100, 420), Color.Black);
            }
            else if (screenState == Screen.Game)
            {
                _spriteBatch.Draw(galaxyBackground, window, Color.White);
                foreach (Brick brick in brickPlacer)
                    brick.Draw(_spriteBatch);
                paddle.Draw(_spriteBatch);
                ball.Draw(_spriteBatch);
                _spriteBatch.Draw(ballTexture, ballRect, Color.White);
                _spriteBatch.DrawString(messageFont, "x " + Convert.ToString(ball.Lives), new Vector2(30, 465), Color.White);

            }
            else if (screenState == Screen.GoodEnd)
            {
                _spriteBatch.Draw(goodBackground, window, Color.White);
                _spriteBatch.DrawString(textFont, "Congratulations!", new Vector2(175, 10), Color.Black);
                _spriteBatch.DrawString(messageFont, "You got rid of all the bricks without losing all of your marbles!", new Vector2(50, 300), Color.Black);
                _spriteBatch.DrawString(messageFont, "Good Job!", new Vector2(350, 330), Color.Black);
            }
            else
            {
                _spriteBatch.Draw(badBackground, window, Color.White);
                _spriteBatch.DrawString(textFont, "Uh Oh! You Lost!", new Vector2(155, 10), Color.White);
                _spriteBatch.DrawString(messageFont, "You lost all your marbles and now are trapped for your crimes!", new Vector2(30, 300), Color.White);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
