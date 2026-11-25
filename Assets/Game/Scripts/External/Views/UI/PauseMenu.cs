using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Views.UI;

namespace Views.UI
{
    public class PauseMenu : MonoBehaviour, IPauseMenu
    {
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private View _view;

        public View View => _view;

        public event Action ResumeButtonClicked;
        public event Action RestartButtonClicked;
        public event Action SettingsButtonClicked;
        public event Action MainMenuButtonClicked;

        private void Awake()
        {
            _resumeButton.onClick.AddListener(() => ResumeButtonClicked?.Invoke());
            _restartButton.onClick.AddListener(() => RestartButtonClicked?.Invoke());
            _settingsButton.onClick.AddListener(() => SettingsButtonClicked?.Invoke());
            _mainMenuButton.onClick.AddListener(() => MainMenuButtonClicked?.Invoke());
        }
    }

}
