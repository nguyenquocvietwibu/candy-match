using System;

namespace Presenter
{
    public class MainMenu
    {
        private readonly IMainMenu _mainMenuView;
        private readonly IViewNavigator _uiNavigator;
        private readonly IScreenNavigator _screenNavigator;
        public MainMenu(IMainMenu mainMenuView, IViewNavigator uiNavigator, IScreenNavigator screenNavigator)
        {
            _mainMenuView = mainMenuView;
            _uiNavigator = uiNavigator;
            _screenNavigator = screenNavigator;

            _mainMenuView.QuitButtonClicked += OnQuitButtonClicked;
            _mainMenuView.PlayButtonClicked += OnPlayButtonClicked;
            _mainMenuView.SettingsButtonClicked += OnSettingsButtonClicked;
        }

        private void OnSettingsButtonClicked()
        {
            _uiNavigator.Show<ISettingsMenu>();
        }

        private async void OnPlayButtonClicked()
        {
            await _screenNavigator.NavigateToAsync(GameScreen.Gameplay);
        }

        private void OnQuitButtonClicked()
        {
            throw new NotImplementedException();
        }
    }
}