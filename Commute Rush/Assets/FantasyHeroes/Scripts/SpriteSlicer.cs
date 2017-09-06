using System.Collections.Generic;
using UnityEngine;

namespace Assets.FantasyHeroes.Scripts
{
    /// <summary>
    /// Implements dynamic sprite caching to improve game performance
    /// </summary>
    public static class SpriteSlicer
    {
        private static readonly Dictionary<long, Sprite> Cache = new Dictionary<long, Sprite>();

        /// <summary>
        /// Clear sprite cache
        /// </summary>
        public static void ClearCache()
        {
            Cache.Clear();
        }

        /// <summary>
        /// Slice texture and return a sprite
        /// </summary>
        public static Sprite Slice(Texture2D texture, SpriteLayout layout)
        {
            var key = texture.GetHashCode() + layout.GetHashCode();

            if (Application.isPlaying && Cache.ContainsKey(key))
            {
                return Cache[key];
            }

            var pivot = new Vector2(layout.Pivot.x / layout.Rect.width, layout.Pivot.y / layout.Rect.height);
            var sprite = Sprite.Create(texture, layout.Rect, pivot, 100, 2, SpriteMeshType.Tight);

            sprite.name = texture.name;

            if (Application.isPlaying)
            {
                Cache.Add(key, sprite);
            }

            return sprite;
        }
    }
}