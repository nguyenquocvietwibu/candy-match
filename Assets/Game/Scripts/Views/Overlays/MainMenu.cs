using View.Overlay;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.Overlay
{
    public class MainMenu : View, IMainMenu
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _quitButton;

        public event Action PlayButtonClicked;
        public event Action SettingsButtonClicked;
        public event Action QuitButtonClicked;

        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            _quitButton.onClick.AddListener(OnQuitButtonClicked);
        }

        private void OnQuitButtonClicked()
        {
            QuitButtonClicked?.Invoke();
        }

        private void OnSettingsButtonClicked()
        {
            SettingsButtonClicked?.Invoke();
        }

        private void OnPlayButtonClicked()
        {
            PlayButtonClicked?.Invoke();
        }
    }
}


