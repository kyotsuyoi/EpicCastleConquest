using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace EpicCastleConquest.Class
{
    internal class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private float speed;
        private bool attacking;

        private readonly AnimationManager _anims = new AnimationManager();

        public Player(Vector2 position)
        {
            this.position = position;
            speed = 100f;
            texture = Globals.Content.Load<Texture2D>("class_knight_female");

            _anims.AddAnimation(new Vector2(0, 1), new Animation(texture, 8, 4, 0, 3, 0.1f, 1));  //Down
            _anims.AddAnimation(new Vector2(1, 0), new Animation(texture, 8, 4, 0, 3, 0.1f, 2));  //Right
            _anims.AddAnimation(new Vector2(-1, 0), new Animation(texture, 8, 4, 0, 3, 0.1f, 3)); //Left
            _anims.AddAnimation(new Vector2(0, -1), new Animation(texture, 8, 4, 0, 3, 0.1f, 4)); //Up

            _anims.AddAnimation(new Vector2(-1, 1), new Animation(texture, 8, 4, 0, 3, 0.1f, 3));  //Down Left
            _anims.AddAnimation(new Vector2(-1, -1), new Animation(texture, 8, 4, 0, 3, 0.1f, 3)); //Up Left
            _anims.AddAnimation(new Vector2(1, 1), new Animation(texture, 8, 4, 0, 3, 0.1f, 2));  //Down Right
            _anims.AddAnimation(new Vector2(1, -1), new Animation(texture, 8, 4, 0, 3, 0.1f, 2)); //Up Right

            _anims.AddAnimation("attack_d", new Animation(texture, 8, 4, 5, 7, 0.1f, 1)); //Attack Down
            _anims.AddAnimation("attack_r", new Animation(texture, 8, 4, 5, 7, 0.1f, 2)); //Attack Right
            _anims.AddAnimation("attack_l", new Animation(texture, 8, 4, 5, 7, 0.1f, 3)); //Attack Left
            _anims.AddAnimation("attack_u", new Animation(texture, 8, 4, 5, 7, 0.1f, 4)); //Attack Up
        }

        //public bool Attacking { get => attacking; set => attacking = value; }
        public void Update()
        {
            if (InputManager.Moving)
            {
                position += Vector2.Normalize(InputManager.Direction) * speed * Globals.TotalSeconds;
            }
            _anims.Update(InputManager.Direction, attacking);

            attacking = false;
            if (InputManager.Attacking)
            {
                string attack_side = "";
                switch (InputManager.Side)
                {
                    case 'U':
                        attack_side = "attack_u";
                        break;

                    case 'R':
                        attack_side = "attack_r";
                        break;

                    case 'L':
                        attack_side = "attack_l";
                        break;

                    case 'D':
                        attack_side = "attack_d";
                        break;
                }
                attacking = true;
                _anims.Update(attack_side, true);
            }

        }

        public void Draw()
        {
            _anims.Draw(position, attacking);
        }

    }
}