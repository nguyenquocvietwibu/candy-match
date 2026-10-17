using System;
using UnityEngine;
using UnityEngine.UI;
using View.Overlay;

namespace View.Overlay
{
    public class PauseMenu : View, IPauseMenu
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        public Button ResumeButton => _resumeButton;
        public Button SettingsButton => _settingsButton;
        public Button RestartButton => _restartButton;
        public Button MainMenuButton => _mainMenuButton;

        public event Action ResumeButtonClicked;
        public event Action RestartButtonClicked;
        public event Action SettingsButtonClicked;
        public event Action MainMenuButtonClicked;

        protected override void Awake()
        {
            base.Awake();
            _resumeButton.onClick.AddListener(OnResumeButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            throw new NotImplementedException();
        }

        private void OnMainMenuButtonClicked()
        {
            MainMenuButtonClicked?.Invoke();
        }

        private void OnSettingsButtonClicked()
        {
            SettingsButtonClicked?.Invoke();
        }

        private void OnResumeButtonClicked()
        {
            throw new NotImplementedException();
        }
    }

}
