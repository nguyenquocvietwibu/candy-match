
using UnityEngine;

namespace View.World
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Candy : View
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public void SetSprite(Sprite value) => _spriteRenderer.sprite = value;
    }
}