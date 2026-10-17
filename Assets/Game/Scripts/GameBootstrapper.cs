using Cysharp.Threading.Tasks;
using Presenter;
using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using View.Overlay;


public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private PrefabProviderSO _prefabProviderSO;
    private void Awake()
    {
        if (_prefabProviderSO == null)
        {
            throw new System.Exception("PrefabProviderSO is not assigned in the inspector.");
        }
    }
    private async void Start()
    {
        await InitAsync();
        Debug.Log("Bootstrapped");
    }
    private async UniTask InitAsync()
    {
        Camera mainCamera = Instantiate(_prefabProviderSO.MainCamera);
        Instantiate(_prefabProviderSO.EventSystem);
        View.Overlay.UI ui = Instantiate(_prefabProviderSO.UI);
        ScreenFader screenFader = Instantiate(_prefabProviderSO.ScreenFader);
        GameplayBg gameplayBgView = Instantiate(_prefabProviderSO.GameplayBg);
        gameplayBgView.SetCanvasRenderModeCamera(mainCamera);

        View.Overlay.MainMenu mainMenuView = ui.MainMenu;
        View.Overlay.SettingsMenu settingsMenuView = ui.SettingsMenu;
        View.Overlay.PauseMenu pauseMenuView = ui.PauseMenu;
        View.Overlay.HUD hudView = ui.HUD;


        Presenter.ViewNavigator uiNavigator = new();

        uiNavigator.Register<IMainMenu>(mainMenuView);
        uiNavigator.Register<ISettingsMenu>(settingsMenuView);
        uiNavigator.Register<IPauseMenu>(pauseMenuView);

        Presenter.GameplayScreen gameplayScreen = new(
            hudView: hudView,
            uiNavigator: uiNavigator,
            gameplayBgView: gameplayBgView);


        Presenter.TitleScreen titleScreen = new(uiNavigator);

        Presenter.ScreenNavigator screenNavigator = new(
            screenFader: screenFader);

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

        await UniTask.NextFrame();
        await screenNavigator.NavigateToAsync(GameScreen.Title);

    }
}
