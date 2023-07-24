using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EpicCastleConquest.Class
{
    internal class Screen
    {
        private GraphicsDeviceManager _graphics;

        public Screen(GraphicsDeviceManager _graphics)
        {
            this._graphics = _graphics;
        }

        public Vector2 screenColision(Vector2 characterPosition, Texture2D characterTexture)
        {
            if (characterPosition.X > _graphics.PreferredBackBufferWidth - characterTexture.Width / 2)
            {
                characterPosition.X = _graphics.PreferredBackBufferWidth - characterTexture.Width / 2;
            }
            else if (characterPosition.X < characterTexture.Width / 2)
            {
                characterPosition.X = characterTexture.Width / 2;
            }

            if (characterPosition.Y > _graphics.PreferredBackBufferHeight - characterTexture.Height / 2)
            {
                characterPosition.Y = _graphics.PreferredBackBufferHeight - characterTexture.Height / 2;
            }
            else if (characterPosition.Y < characterTexture.Height / 2)
            {
                characterPosition.Y = characterTexture.Height / 2;
            }

            return characterPosition;
        }
    }
}
