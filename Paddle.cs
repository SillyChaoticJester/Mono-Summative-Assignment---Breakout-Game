using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Mono_Summative_Assignment___Breakout_Game
{
    public class Paddle
    {
        Texture2D _texture;
        Rectangle _rect, _window;
        Vector2 _speed;

        public Paddle(Texture2D texture, Rectangle rect)
        {
            _texture = texture;
            _rect = rect;
            //_window = window;
            _speed = Vector2.Zero;
        }

        public void Update(KeyboardState keyboardState)
        {
            _speed = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.A))
            {
                _speed.X += -3;
            }
            
            if (keyboardState.IsKeyDown(Keys.D))
            {
                _speed.X += 3;
            }
            
            _rect.Offset(_speed);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rect, Color.White);
        }

        public Rectangle Rect
        {
            get { return _rect; }
        }
    }
}
