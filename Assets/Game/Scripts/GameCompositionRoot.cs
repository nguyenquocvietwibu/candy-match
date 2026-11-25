using Core;
using Cysharp.Threading.Tasks;
using External;
using System;
using System.Collections.Generic;
using UnityEngine;
using Views.UI;
using Views.World;


public class GameCompositionRoot : MonoBehaviour
{
    //[SerializeField] private PrefabProviderSO _prefabProviderSO;
    //[SerializeField] private CandyDatabaseSO _candyDbSO;
    [SerializeField] private GameUI _gameUI;
    private async void Start()
    {
        await InitAsync();
    }

    private async UniTask InitAsync()
    {
        IMainMenu mainMenu = _gameUI.MainMenu;
        IPauseMenu pauseMenu = _gameUI.PauseMenu;
        ISettingsMenu settingsMenu = _gameUI.SettingsMenu;
        IHUD hud = _gameUI.HUD;
        ITimeToReadyPopup timeToReadyPopup = _gameUI.TimeToReadyPopup;
        IConfirmationPopup restartConfirmationPopup = _gameUI.RestartConfirmationPopup;
        IConfirmationPopup mainMenuConfirmationPopup = _gameUI.MainMenuConfirmationPopup;
        IView mainMenuView = _gameUI.MainMenu.View;
        IView restartConfirmationPopupView = _gameUI.RestartConfirmationPopup.View;

        ViewGroup gameplayViewGroup = new(
            new HashSet<IView>
            {
                _gameUI.GameplayBg.View,
                _gameUI.TimeToReadyPopup.View
            });

        Dictionary<GameSceneCategory, IView> sceneViewDict = new()
        {
            [GameSceneCategory.Title] = _gameUI.MainMenu.View,
            [GameSceneCategory.Gameplay] = gameplayViewGroup,
        };

        Dictionary<UIModalCategory, IView> uiModalViewDict = new()
        {
            [UIModalCategory.PauseMenu] = _gameUI.PauseMenu.View,
            [UIModalCategory.SettingsMenu] = _gameUI.SettingsMenu.View,
            [UIModalCategory.RestartConfirmationPopup] = _gameUI.RestartConfirmationPopup.View,
            [UIModalCategory.MainMenuConfirmationPopup] = _gameUI.MainMenuConfirmationPopup.View,
        };

        UIModalNavigator uiModalNavigator = new(uiModalViewDict);

        SceneNavigator sceneNavigator = new(
            screenFader: _gameUI.ScreenFader,
            sceneViewDict: sceneViewDict);

        SceneCoordinator sceneCoordinator = new(
            sceneNavigator: sceneNavigator,
            pauseMenu: pauseMenu,
            mainMenu: mainMenu,
            restartConfirmationPopup: restartConfirmationPopup,
            mainMenuConfirmationPopup: mainMenuConfirmationPopup);

        UIModalCoordinator uiModalCoordinator = new(
            sceneCoordinator: sceneCoordinator,
            uiModalNavigator: uiModalNavigator,
            mainMenu: mainMenu,
            settingsMenu: settingsMenu,
            pauseMenu: pauseMenu,
            hud: hud,
            restartConfirmationPopup: restartConfirmationPopup,
            mainMenuConfirmationPopup: mainMenuConfirmationPopup);

        GameplayCoordinator gameplayCoordinator = new(
            sceneCoordinator: sceneCoordinator,
            timeToReadyPopup: timeToReadyPopup,
            pauseMenu: pauseMenu,
            restartConfirmationPopup: restartConfirmationPopup,
            mainMenuConfirmationPopup: mainMenuConfirmationPopup,
            hud: hud,
            worldTimeService: new WorldTimeService());


        await UniTask.Delay(TimeSpan.FromSeconds(1));
        await sceneNavigator.NavigateToAsync(GameSceneCategory.Title);
    }

}
