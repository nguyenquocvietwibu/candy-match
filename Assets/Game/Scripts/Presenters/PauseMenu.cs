using System;

namespace Presenter
{
    public class PauseMenu
    {
        private readonly IPauseMenu _pauseMenuView;
        private readonly IViewNavigator _uiNavigator;
        private readonly IScreenNavigator _screenNavigator;
        public PauseMenu(IPauseMenu pauseMenuView, IViewNavigator uiNavigator, IScreenNavigator screenNavigator)
        {
            _pauseMenuView = pauseMenuView;
            _uiNavigator = uiNavigator;
            _screenNavigator = screenNavigator;

            _pauseMenuView.MainMenuButtonClicked += OnMainMenuButtonClicked;
            _pauseMenuView.SettingsButtonClicked += OnSettingsButtonClicked;
        }

        private void OnSettingsButtonClicked()
        {
            _uiNavigator.Hide<IPauseMenu>();
            _uiNavigator.Show<ISettingsMenu>();
        }

        private async void OnMainMenuButtonClicked()
        {
            await _screenNavigator.NavigateToAsync(GameScreen.Title);
        }
    }
}