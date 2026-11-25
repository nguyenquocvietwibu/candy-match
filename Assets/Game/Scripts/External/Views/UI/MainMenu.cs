using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class MainMenu : MonoBehaviour, IMainMenu
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private View _view;

        public View View => _view;

        public event Action PlayButtonClicked;
        public event Action SettingsButtonClicked;
        public event Action QuitButtonClicked;

        private void Awake()
        {
            _playButton.onClick.AddListener(() => PlayButtonClicked?.Invoke());
            _settingsButton.onClick.AddListener(() => SettingsButtonClicked?.Invoke());
            _quitButton.onClick.AddListener(() =>QuitButtonClicked?.Invoke());
        }

    }
}


