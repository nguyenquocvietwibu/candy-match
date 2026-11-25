
using System;
using UnityEngine;
using Utils;

namespace Views.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private SettingsMenu _settingsMenu;
        [SerializeField] private PauseMenu _pauseMenu;
        [SerializeField] private HUD _hud;
        [SerializeField] private GameplayBg _gameplayBg;
        [SerializeField] private ScreenFader _screenFader;
        [SerializeField] private TimeToReadyPopup _timeToReadyPopup;
        [SerializeField] private ConfirmationPopup _restartConfirmationPopup;
        [SerializeField] private ConfirmationPopup _mainMenuConfirmationPopup;
        public ConfirmationPopup RestartConfirmationPopup => _restartConfirmationPopup;
        public ConfirmationPopup MainMenuConfirmationPopup => _mainMenuConfirmationPopup;
        public MainMenu MainMenu => _mainMenu;
        public HUD HUD => _hud;
        public SettingsMenu SettingsMenu => _settingsMenu;
        public PauseMenu PauseMenu => _pauseMenu;
        public GameplayBg GameplayBg => _gameplayBg;
        public ScreenFader ScreenFader => _screenFader;
        public TimeToReadyPopup TimeToReadyPopup => _timeToReadyPopup;
        public event Action ResumeButtonClicked;
        public event Action RestartButtonClicked;
        public event Action SettingsButtonClicked;
        public event Action MainMenuButtonClicked;

        private void Awake()
        {
            GameObjectActivator.ActiveChildrensFrom(transform);
        }

    }

}
