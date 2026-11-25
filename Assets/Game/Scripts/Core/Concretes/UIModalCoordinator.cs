using System;
using System.Collections;
using Views.UI;

namespace Core
{
    public class UIModalCoordinator
    {
        private readonly IMainMenu _mainMenu;
        private readonly IHUD _hud;
        private readonly ISettingsMenu _settingsMenu;
        private readonly IPauseMenu _pauseMenu;
        private readonly UIModalNavigator _uiModalNavigator;
        private readonly SceneCoordinator _sceneCoordinator;
        private IConfirmationPopup _restartConfirmationPopup;
        private IConfirmationPopup _mainMenuConfirmationPopup;
        public UIModalCoordinator(
            SceneCoordinator sceneCoordinator,
            UIModalNavigator uiModalNavigator,
            IMainMenu mainMenu, 
            IHUD hud,
            ISettingsMenu settingsMenu,
            IPauseMenu pauseMenu,
            IConfirmationPopup restartConfirmationPopup,
            IConfirmationPopup mainMenuConfirmationPopup)
        {
            _mainMenu = mainMenu;
            _hud = hud;
            _settingsMenu = settingsMenu;
            _pauseMenu = pauseMenu;
            _uiModalNavigator = uiModalNavigator;
            _sceneCoordinator = sceneCoordinator;
            _restartConfirmationPopup = restartConfirmationPopup;
            _mainMenuConfirmationPopup = mainMenuConfirmationPopup;

            _sceneCoordinator.SceneChanging += OnSceneChanging;
            _mainMenu.SettingsButtonClicked += OnSettingsButtonClicked;
            _pauseMenu.SettingsButtonClicked += OnSettingsButtonClicked;
            _settingsMenu.BackButtonClicked += OnSettingsMenuBackButtonClicked;
            _pauseMenu.ResumeButtonClicked += OnResumeButtonClicked;
            _hud.PauseButtonClicked += OnPauseButtonClicked;
            _pauseMenu.RestartButtonClicked += OnRestartButtonClicked;
            _pauseMenu.MainMenuButtonClicked += OnMainMenuButtonClicked;
            _restartConfirmationPopup.CancelButtonClicked += OnRestartCancelButtonCLicked;
            _mainMenuConfirmationPopup.CancelButtonClicked += OnMainMenuCancelButtonClicked;
        }

        private void OnMainMenuCancelButtonClicked()
        {
            _uiModalNavigator.Hide(UIModalCategory.MainMenuConfirmationPopup);
        }

        private void OnRestartCancelButtonCLicked()
        {
            _uiModalNavigator.Hide(UIModalCategory.RestartConfirmationPopup);
        }

        private void OnMainMenuButtonClicked()
        {
            _uiModalNavigator.Show(UIModalCategory.MainMenuConfirmationPopup);
        }

        private void OnRestartButtonClicked()
        {
            _uiModalNavigator.Show(UIModalCategory.RestartConfirmationPopup);
        }

        private void OnSceneChanging()
        {
            _uiModalNavigator.Clear();
        }

        private void OnSettingsButtonClicked()
        {
            _uiModalNavigator.Show(UIModalCategory.SettingsMenu);
        }

        private void OnPauseButtonClicked()
        {
            _uiModalNavigator.Show(UIModalCategory.PauseMenu);
        }

        private void OnResumeButtonClicked()
        {
            _uiModalNavigator.Hide(UIModalCategory.PauseMenu);
        }

        private void OnSettingsMenuBackButtonClicked()
        {
            _uiModalNavigator.Hide(UIModalCategory.SettingsMenu);
        }
    }
}