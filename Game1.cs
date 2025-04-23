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
        Texture2D brickTexture;
        Texture2D ballTexture;

        Rectangle ballRect;
        Rectangle brickRect;
        Rectangle paddleRect;

        List<Brick> bricks;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            paddleTexture = Content.Load<Texture2D>("Images/paddle");
            brickTexture = Content.Load<Texture2D>("Images/rectangle (1)");
            ballTexture = Content.Load<Texture2D>("Images/circle (1)");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
