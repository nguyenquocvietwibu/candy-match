using System;

namespace Presenter
{
    public class HUD
    {
        private readonly IHUD _hudView;
        private readonly IViewNavigator _uiNavigator;
        public HUD(IHUD hudView, IViewNavigator uiNavigator)
        {
            _hudView = hudView;
            _uiNavigator = uiNavigator;

            _hudView.PauseButtonClicked += OnPauseButtonClicked;

        }

        private void OnPauseButtonClicked()
        {
            _uiNavigator.Show<IPauseMenu>();
        }
    }
}