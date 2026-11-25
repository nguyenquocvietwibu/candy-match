using UnityEngine;

namespace Views.UI
{
    [RequireComponent(typeof(Canvas))]
    public class GameplayBg : MonoBehaviour
    {
        [SerializeField] Canvas _canvas;
        [SerializeField] private View _view;
        public View View => _view;
        public void SetCanvasRenderModeCamera(Camera camera)
        {
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = camera;
        }
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }
    }
}