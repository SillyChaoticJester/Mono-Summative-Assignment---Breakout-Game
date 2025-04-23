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
        private Texture2D _texture;

        public Brick(Texture2D texture, Rectangle location)
        {
            _texture = texture;
            _location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, Color.White);
        }
    }
}
