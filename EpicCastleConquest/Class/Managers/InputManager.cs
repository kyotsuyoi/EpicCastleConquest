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
        private static bool _running;
        public static bool Running => _running;

        private static char _side;
        public static char Side => _side;

        public static bool Attacking { get => _attacking; set => _attacking = value; }

        public static void Update()
        {
            _direction = Vector2.Zero;
            var keyboardState = Keyboard.GetState();

            if (keyboardState.GetPressedKeyCount() > 0)
            {
                if (keyboardState.IsKeyDown(Keys.A) || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
                {
                    _direction.X--;
                    _side = 'L';
                }

                if (keyboardState.IsKeyDown(Keys.D) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
                {
                    _direction.X++;
                    _side = 'R';
                }

                if (keyboardState.IsKeyDown(Keys.W) || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
                {
                    _direction.Y--;
                    _side = 'U';
                }

                if (keyboardState.IsKeyDown(Keys.S) || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
                {
                    _direction.Y++;
                    _side = 'D';
                }

                if(_direction.X==-1 && _direction.Y==1)
                {
                    var c = 'c';
                }

                if (keyboardState.IsKeyDown(Keys.G) || GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed) 
                { 
                    _attacking = true; 
                }

                if (keyboardState.IsKeyDown(Keys.H) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                {
                    _running = true;
                }
                else
                {
                    _running = false;
                }
            }
        }
    }
}

