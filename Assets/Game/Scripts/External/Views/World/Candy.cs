
using UnityEngine;

namespace Views.World
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Candy : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
        public Sprite Sprite
        {
            get => _spriteRenderer.sprite;
            set => _spriteRenderer.sprite = value;
        }
    }
}