using UnityEngine;

namespace View.Overlay
{
    [RequireComponent(typeof(Canvas))]
    public class GameplayBg : View
    {
        [SerializeField] Canvas _canvas;
        public void SetCanvasRenderModeCamera(Camera camera)
        {
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = camera;
        }
        protected override void Awake()
        {
            base.Awake();
            _canvas = GetComponent<Canvas>();
        }
    }
}