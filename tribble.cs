using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_with_monogame___Hunter
{
    class tribble
    {
        private Rectangle _rectangle;
        private Vector2 _speed;
        private Texture2D _texture;

        public tribble (Rectangle rectangle, Vector2 speed, Texture2D texture)
        {
            _rectangle = rectangle;
            _speed = speed;
            _texture = texture;
        }

        public Texture2D Texture
        {
            get { return _texture; }
        }

        public Rectangle BoundRect
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public void Move(GraphicsDeviceManager graphics)
        {
            _rectangle.Offset(_speed);
            if (_rectangle.Right > graphics.PreferredBackBufferWidth || _rectangle.Left < 0)
            {
                _speed.X *= -1;
            }
            if (_rectangle.Bottom > graphics.PreferredBackBufferHeight || _rectangle.Top < 0)
            {
                _speed.Y *= -1;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}
