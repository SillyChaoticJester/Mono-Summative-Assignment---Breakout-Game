using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono_Summative_Assignment___Breakout_Game
{
    public class Brick
    {
        private Rectangle _location;
        private List<Texture2D> _texture;
        private Color _color;

        public Brick(List<Texture2D> texture, Rectangle location, Color color)
        {
            _texture = texture;
            _location = location;
            _color = color;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture[0], _location, _color);
        }

        public bool Contains(Rectangle ball)
        {
            return _location.Contains(ball);
        }

        public bool Intersects(Rectangle rect)
        {
            return _location.Intersects(rect);
        }


        public void Update(Rectangle ball)
        {

        }

    }
}
