using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Summative_Assignment___Breakout_Game
{
    public class Ball
    {
        private Rectangle _location;
        private Texture2D _texture;
        private Vector2 _speed;
        private int _lives;

        public Ball(Texture2D textures, Rectangle location)
        {
            _texture = textures;
            _location = location;
            _speed = new Vector2(2, 2);
            _lives = 3;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }

        public void Update(GraphicsDeviceManager graphics, Rectangle player, List<Brick> collision)
        {
            if (_location.Right > graphics.PreferredBackBufferWidth || _location.Left < 0)
            {
                _speed.X *= -1;
            }

            if (_location.Top < 0)
            {
                _speed.Y *= -1;
            }

            if (_location.Y > graphics.PreferredBackBufferHeight)
            {
                _location.X = 385;
                _location.Y = 375;
                _lives--;
            }
            
            if (_location.Intersects(player))
            {
                _speed.Y *= -1;
            }

            
            //if (_location.Intersects(collision))

            _location.X += (int)_speed.X;

            for (int i = 0; i < collision.Count; i++)
            {
                if (collision[i].Intersects(_location))
                {
                    collision.RemoveAt(i);
                    i--;
                    _speed.X *= -1;

                }
            }

            _location.Y += (int)_speed.Y;
            for (int i = 0; i < collision.Count; i++)
            {
                if (collision[i].Intersects(_location))
                {
                    collision.RemoveAt(i);
                    i--;
                    _speed.Y *= -1;
                }
            }
        }

        public Rectangle Rect
        {
            get { return _location; }
        }

        public int Lives
        {
            get { return _lives; }
        }

        public bool Intersects(Rectangle player)
        {
            return _location.Intersects(player);
        }

        
    }
}
