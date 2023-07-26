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
        //private bool running;

        private readonly AnimationManager _anims = new AnimationManager();

        public Player(Vector2 position)
        {
            this.position = position;
            speed = 100f;

            //texture = Globals.Content.Load<Texture2D>("assassin_walk");
            //_anims.AddAnimation(new Vector2(0, 1), new Animation(texture, 8, 16, 0, 15, 0.1f, 1));  //Down
            //_anims.AddAnimation(new Vector2(1, 0), new Animation(texture, 8, 16, 0, 15, 0.1f, 13));  //Right
            //_anims.AddAnimation(new Vector2(-1, 0), new Animation(texture, 8, 16, 0, 15, 0.1f, 5)); //Left
            //_anims.AddAnimation(new Vector2(0, -1), new Animation(texture, 8, 16, 0, 15, 0.1f, 9)); //Up

            //_anims.AddAnimation(new Vector2(-1, 1), new Animation(texture, 8, 16, 0, 15, 0.1f, 3));  //Down Left
            //_anims.AddAnimation(new Vector2(-1, -1), new Animation(texture, 8, 16, 0, 15, 0.1f, 7)); //Up Left
            //_anims.AddAnimation(new Vector2(1, 1), new Animation(texture, 8, 16, 0, 15, 0.1f, 15));  //Down Right
            //_anims.AddAnimation(new Vector2(1, -1), new Animation(texture, 8, 16, 0, 15, 0.1f, 11)); //Up Right

            texture = Globals.Content.Load<Texture2D>("class_knight_female");
            _anims.AddAnimation(new Vector2(0, 1), null, new Animation(texture, 8, 4, 0, 3, 0.1f, 1));  //Down
            _anims.AddAnimation(new Vector2(1, 0), null, new Animation(texture, 8, 4, 0, 3, 0.1f, 2));  //Right
            _anims.AddAnimation(new Vector2(-1, 0), null, new Animation(texture, 8, 4, 0, 3, 0.1f, 3)); //Left
            _anims.AddAnimation(new Vector2(0, -1), null, new Animation(texture, 8, 4, 0, 3, 0.1f, 4)); //Up

            //_anims.AddAnimation(new Vector2(-1, 1), "DL", new Animation(texture, 8, 4, 0, 3, 0.1f, 3));  //Down Left
            //_anims.AddAnimation(new Vector2(-1, -1), "UL", new Animation(texture, 8, 4, 0, 3, 0.1f, 3)); //Up Left
            //_anims.AddAnimation(new Vector2(1, 1), "DR", new Animation(texture, 8, 4, 0, 3, 0.1f, 2));  //Down Right
            //_anims.AddAnimation(new Vector2(1, -1), "UR", new Animation(texture, 8, 4, 0, 3, 0.1f, 2)); //Up Right

            //_anims.AddAnimation(new Vector2(-1, 1), "LD", new Animation(texture, 8, 4, 0, 3, 0.1f, 1));  //Left Down 
            //_anims.AddAnimation(new Vector2(-1, -1), "LU", new Animation(texture, 8, 4, 0, 3, 0.1f, 4)); //Left Up 
            //_anims.AddAnimation(new Vector2(1, 1), "RD", new Animation(texture, 8, 4, 0, 3, 0.1f, 1));  //Right Down
            //_anims.AddAnimation(new Vector2(1, -1), "RU", new Animation(texture, 8, 4, 0, 3, 0.1f, 4)); //Right Up

            _anims.AddAnimation("attack_d", null, new Animation(texture, 8, 4, 5, 7, 0.1f, 1)); //Attack Down
            _anims.AddAnimation("attack_r", null, new Animation(texture, 8, 4, 5, 7, 0.1f, 2)); //Attack Right
            _anims.AddAnimation("attack_l", null, new Animation(texture, 8, 4, 5, 7, 0.1f, 3)); //Attack Left
            _anims.AddAnimation("attack_u", null, new Animation(texture, 8, 4, 5, 7, 0.1f, 4)); //Attack Up
        }

        //public bool Attacking { get => attacking; set => attacking = value; }
        public void Update()
        {
            if (InputManager.Moving)
            {
                speed = 100f;
                if (InputManager.Running)
                {
                    speed *= 2;
                }
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
                _anims.Update(attack_side);
            }

        }

        public void Draw()
        {
            _anims.Draw(position, attacking);
        }

    }
}