using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace EpicCastleConquest.Class
{
    public class AnimationManager
    {
        private readonly Dictionary<object, Animation> _anims = new Dictionary<object, Animation>();
        private object _lastKey;

        public void AddAnimation(object key, Animation animation)
        {
            _anims.Add(key, animation);
            _lastKey = key;
        }

        public void Update(object key,bool attacking)
        {
            if (_anims.TryGetValue(key, out Animation value))
            {
                value.Start();
                _anims[key].Update();
                _lastKey = key;
            }
            else
            {
                if (attacking) return;
                _anims[_lastKey].Stop();
                _anims[_lastKey].Reset();
            }
        }

        public void Draw(Vector2 position, bool attacking)
        {
            _anims[_lastKey].Draw(position, attacking);
        }
    }

}