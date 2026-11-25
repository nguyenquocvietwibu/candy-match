using System;
using System.Collections;

namespace Core
{
    public class SceneCoordinator
    {
        private SceneNavigator _sceneNavigator;
        private IMainMenu _mainMenu;
        private IPauseMenu _pauseMenu;
        private IConfirmationPopup _restartConfirmationPopup;
        private IConfirmationPopup _mainMenuConfirmationPopup;
        public event Action ChangedToGameplayScene;
        public event Action ChangingToGameplayScene;
        public event Action SceneChanging;
        public SceneCoordinator(
            SceneNavigator sceneNavigator,
            IPauseMenu pauseMenu,
            IMainMenu mainMenu, 
            IConfirmationPopup restartConfirmationPopup,
            IConfirmationPopup mainMenuConfirmationPopup)
        {
            _restartConfirmationPopup = restartConfirmationPopup;
            _mainMenuConfirmationPopup = mainMenuConfirmationPopup;
            _sceneNavigator = sceneNavigator;
            _pauseMenu = pauseMenu;
            _mainMenu = mainMenu;

            _mainMenu.PlayButtonClicked += OnPlayButtonClicked;
            _mainMenuConfirmationPopup.ConfirmButtonClicked += OnMainMenuButtonClicked;
            _restartConfirmationPopup.ConfirmButtonClicked += OnPlayButtonClicked;
        }

        private async void OnMainMenuButtonClicked()
        {
            await _sceneNavigator.NavigateToAsync(GameSceneCategory.Title, OnGameplaySceneChanging);
        }

        private async void OnPlayButtonClicked()
        {
            await _sceneNavigator.NavigateToAsync(GameSceneCategory.Gameplay, OnGameplaySceneChanging);
            ChangedToGameplayScene?.Invoke();
        }

        private void OnGameplaySceneChanging()
        {
            SceneChanging?.Invoke();
            ChangingToGameplayScene?.Invoke();
        }
    }
}
