using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicCastleConquest.Class
{
    internal class Keypad
    {
        Vector2 characterPosition;
        public Keypad(Vector2 characterPosition)
        {
            //(float)gameTime.ElapsedGameTime.TotalSeconds
            this.characterPosition = characterPosition;
        }

        public Vector2 Move(float characterSpeed, float TotalSeconds)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape));

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed)
            {
                characterPosition.Y -= characterSpeed * TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed)
            {
                characterPosition.Y += characterSpeed * TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed)
            {
                characterPosition.X -= characterSpeed * TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed)
            {
                characterPosition.X += characterSpeed * TotalSeconds;
            }

            return characterPosition;
        }
    }
}
