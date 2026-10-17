using System;

namespace Presenter
{
    public class SettingsMenu
    {
        private readonly ISettingsMenu _settingsMenuView;
        private readonly IViewNavigator _uiNavigator;

        public SettingsMenu(ISettingsMenu settingsMenuView, IViewNavigator uiNavigator)
        {
            _settingsMenuView = settingsMenuView;
            _uiNavigator = uiNavigator;

            _settingsMenuView.BackButtonClicked += OnBackButtonClicked;
        }

        private void OnBackButtonClicked()
        {
            _uiNavigator.Hide<ISettingsMenu>();
            _uiNavigator.ShowPrevious();
        }
    }
}