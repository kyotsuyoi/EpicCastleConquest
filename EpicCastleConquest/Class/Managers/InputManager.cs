using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EpicCastleConquest.Class
{
    public static class InputManager
    {
        private static Vector2 _direction;
        public static Vector2 Direction => _direction;
        public static bool Moving => _direction != Vector2.Zero;

        private static bool _attacking;

        private static char _side;
        public static char Side => _side;

        public static bool Attacking { get => _attacking; set => _attacking = value; }

        public static void Update()
        {
            _direction = Vector2.Zero;
            var keyboardState = Keyboard.GetState();

            if (keyboardState.GetPressedKeyCount() > 0)
            {
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    _direction.X--;
                    _side = 'L';
                }

                if (keyboardState.IsKeyDown(Keys.D))
                {
                    _direction.X++;
                    _side = 'R';
                }

                if (keyboardState.IsKeyDown(Keys.W))
                {
                    _direction.Y--;
                    _side = 'U';
                }

                if (keyboardState.IsKeyDown(Keys.S))
                {
                    _direction.Y++;
                    _side = 'D';
                }

                if (keyboardState.IsKeyDown(Keys.G)) _attacking = true;
            }
        }
    }
}

