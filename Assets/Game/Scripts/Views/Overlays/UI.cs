
using UnityEngine;

namespace View.Overlay
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private SettingsMenu _settingsMenu;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private HUD _hud;
        public MainMenu MainMenu => _mainMenu;
        public HUD HUD => _hud;
        public SettingsMenu SettingsMenu => _settingsMenu;
        public PauseMenu PauseMenu => _pauseMenu;
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
            ActivateChildrensFrom(transform);
        }

        void ActivateChildrensFrom(Transform parent)
        {
            foreach (Transform child in parent)
            {
                child.gameObject.SetActive(true);
                ActivateChildrensFrom(child);
            }
        }
        

        public void Hide()
        {
            gameObject.SetActive(false);
            _canvas.enabled = false;
        }

        public void SetCanvasRenderModeCamera(Camera camera)
        {
            _canvas.renderMode = RenderMode.ScreenSpaceCamera;
            _canvas.worldCamera = camera;
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _canvas.enabled = true;
        }
    }

}
