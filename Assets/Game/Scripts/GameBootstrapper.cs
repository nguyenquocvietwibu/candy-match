using Cysharp.Threading.Tasks;
using Presenter;
using System;
using System.Collections.Generic;
using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using View.Overlay;
using View.World;


public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private PrefabProviderSO _prefabProviderSO;
    private async void Awake()
    {
        await InitAsync();
    }

    private async UniTask InitAsync()
    {
        Camera mainCamera = Instantiate(_prefabProviderSO.MainCamera);
        Instantiate(_prefabProviderSO.EventSystem);
        View.Overlay.UI ui = Instantiate(_prefabProviderSO.UI);
        ScreenFader screenFader = Instantiate(_prefabProviderSO.ScreenFader);
        GameplayBg gameplayBgView = Instantiate(_prefabProviderSO.GameplayBg);
        gameplayBgView.SetCanvasRenderModeCamera(mainCamera);
        Board boardView = Instantiate(_prefabProviderSO.Board);

        View.Overlay.MainMenu mainMenuView = ui.MainMenu;
        View.Overlay.SettingsMenu settingsMenuView = ui.SettingsMenu;
        View.Overlay.PauseMenu pauseMenuView = ui.PauseMenu;
        View.Overlay.HUD hudView = ui.HUD;


        Presenter.ViewNavigator uiNavigator = new();

        uiNavigator.Register<ISettingsMenu>(settingsMenuView);
        uiNavigator.Register<IPauseMenu>(pauseMenuView);

        Presenter.GameplayScreen gameplayScreen = new(
            hudView: hudView,
            gameplayBgView: gameplayBgView,
            boardView: boardView);


        Presenter.TitleScreen titleScreen = new(mainMenuView);

        Presenter.ScreenNavigator screenNavigator = new(
            screenFader: screenFader,
            uiNavigator: uiNavigator);

        screenNavigator.Register(GameScreen.Title, titleScreen);
        screenNavigator.Register(GameScreen.Gameplay, gameplayScreen);

        new Presenter.MainMenu(
            mainMenuView: mainMenuView,
            screenNavigator: screenNavigator,
            uiNavigator: uiNavigator);

        new Presenter.HUD(
            hudView: hudView,
            uiNavigator: uiNavigator);

        new Presenter.SettingsMenu(
            settingsMenuView: settingsMenuView,
            uiNavigator: uiNavigator);

        new Presenter.PauseMenu(
            pauseMenuView: pauseMenuView,
            uiNavigator: uiNavigator,
            screenNavigator: screenNavigator);

        await UniTask.DelayFrame(3);
        await screenNavigator.NavigateToAsync(GameScreen.Title);
    }
}
