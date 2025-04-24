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

        public Ball(Texture2D textures, Rectangle location)
        {
            _texture = textures;
            _location = location;
            _speed = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }
    }
}
