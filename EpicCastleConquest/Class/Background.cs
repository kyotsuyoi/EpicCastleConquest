using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace EpicCastleConquest.Class
{
    internal class Background
    {
        private Texture2D Texture;
        private Vector2 position;
        public Background(Vector2 position) 
        {
            Texture = Globals.Content.Load<Texture2D>("ground");
            this.position = new Vector2(position.X - Texture.Width/2, position.Y - Texture.Height/2);
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(Texture, position, null, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
        }
    }
}
