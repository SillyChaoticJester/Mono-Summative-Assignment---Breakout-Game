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

        Rectangle ballRect;
        Rectangle brickRect;
        Rectangle paddleRect;

        Brick bricks;
        Paddle paddle;

        //List<Brick> bricks;
        List<Texture2D> brickTextures;

        KeyboardState keyboardState;

        //Things to do:
        //Make a Brick Class, give it properties to have a different position, size, color etc.
        //Make a Brick List afterwards, and make it to where they have to get placed next to each other
        //Make a Ball Class and give it all of its functions
        //Make a Paddle Class and give it all of its functions

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            paddleRect = new Rectangle(0, 0, 25, 25);
            brickTextures = new List<Texture2D>();

            base.Initialize();

            bricks = new Brick(brickTextures, new Rectangle(25, 25, 40, 25));
            paddle = new Paddle(paddleTexture, new Rectangle(200, 100, 100, 20));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            paddleTexture = Content.Load<Texture2D>("Images/paddle");
            ballTexture = Content.Load<Texture2D>("Images/circle");
            brickTextures.Add(Content.Load<Texture2D>("Images/rectangle"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            keyboardState = Keyboard.GetState();
            paddle.Update(keyboardState);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            bricks.Draw(_spriteBatch);
            paddle.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
