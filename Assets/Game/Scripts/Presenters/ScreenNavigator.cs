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
        public ScreenNavigator(IFader screenFader)
        {
            _screenFader = screenFader;
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
                _currentScreen.Hide();
            }
            _currentScreen = screenView;
            _currentScreen.Show();
            await _screenFader.FadeInAsync();
        }
    }
}
