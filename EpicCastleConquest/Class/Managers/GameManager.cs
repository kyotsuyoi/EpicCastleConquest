using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace EpicCastleConquest.Class
{
    public class GameManager
    {
        private Background background;
        private Player player;

        public void Init(Vector2 position)
        {
            background = new Background(position);
            player = new Player(position);
        }

        public void Update()
        {
            InputManager.Update();
            //background.Update();
            player.Update();
        }

        public void Draw()
        {
            background.Draw();
            player.Draw();
        }
    }
}