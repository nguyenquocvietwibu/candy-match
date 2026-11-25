using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace Views.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class UIPaddingApplier : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private float _top;
        [SerializeField] private float _bottom;
        [SerializeField] private float _left;
        [SerializeField] private float _right;
        private void Awake()
        {
            ApplyPadding();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            EditorApplication.delayCall += () =>
            {
                if (this == null) return;
                ApplyPadding();
            };
        }
#endif

        private void ApplyPadding()
        {
            _rectTransform = GetComponent<RectTransform>();

            // offsetMin quản lý (left, bottom)
            _rectTransform.offsetMin = new Vector2(_left, _bottom);

            // offsetMax quản lý (right, top), giá trị right top phải mang dấu âm;
            _rectTransform.offsetMax = new Vector2(-_right, -_top);
        }
    }

}
