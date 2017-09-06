using UnityEngine;

namespace Assets.FantasyHeroes.Scripts
{
    /// <summary>
    /// Contains sprite layout: rect and pivot
    /// </summary>
    public class SpriteLayout : MonoBehaviour
    {
        public Rect Rect;
        public Vector2 Pivot;

        public new long GetHashCode()
        {
            return Rect.GetHashCode() + Pivot.GetHashCode();
        }
    }
}