using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presenter
{
    public class ScreenNavigator : IScreenNavigator
    {
        private IView _currentScreen;
        private readonly Dictionary<GameScreen, IView> _screenDict = new();
        private readonly IFader _screenFader;
        private readonly IViewNavigator _uiNavigator;
        public ScreenNavigator(IFader screenFader, IViewNavigator uiNavigator)
        {
            _screenFader = screenFader;
            _uiNavigator = uiNavigator;
        }
        public void Register(GameScreen screenType, IView screenView)
        {
            _screenDict[screenType] = screenView;
        }
        public async Task NavigateToAsync(GameScreen screenType)
        {
            if (!_screenDict.TryGetValue(screenType, out IView screenView))
            {
                throw new Exception($"Screen of type {screenType} is not registered.");
            }
            if (_currentScreen != null)
            {
                await _screenFader.FadeOutAsync();
                _uiNavigator.HideAll();
                _currentScreen.Hide();
            }
            _currentScreen = screenView;
            _currentScreen.Show();
            await _screenFader.FadeInAsync();
        }
    }
}
