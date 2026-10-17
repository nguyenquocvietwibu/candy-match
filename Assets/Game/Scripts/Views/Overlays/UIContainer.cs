using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace View.Overlay
{
    [RequireComponent(typeof(RectTransform))]
    public class UIContainer : MonoBehaviour
    {
        [SerializeField] private UIContainerSO _uiContainerSO;
        [SerializeField] private RectTransform _rectTransform;

        private void Awake()
        {
            if (_uiContainerSO == null) 
                throw new System.Exception("UIContainerSO is not assigned in the inspector.");
            ApplyPadding();
        }
        private void OnValidate()
        {
#if UNITY_EDITOR
            EditorApplication.delayCall += () =>
            {
                if (this == null) return;
                ApplyPadding();
            };
#endif
        }

        private void ApplyPadding()
        {
            _rectTransform = GetComponent<RectTransform>();

            float horizontalPadding = _uiContainerSO.HorizontalPadding;
            float verticalPadding = _uiContainerSO.VerticalPadding;

            // offsetMin quản lý (left, bottom)
            _rectTransform.offsetMin = new Vector2(horizontalPadding, verticalPadding);

            // offsetMax quản lý (right, top), giá trị right top phải mang dấu âm;
            _rectTransform.offsetMax = new Vector2(-horizontalPadding, -verticalPadding);
        }
    }

}
