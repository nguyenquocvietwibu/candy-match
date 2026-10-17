namespace Presenter
{
    public class TitleScreen : IView
    {
        private readonly IViewNavigator _uiNavigator;
        public TitleScreen(IViewNavigator uiNavigator)
        {
            _uiNavigator = uiNavigator;
        }
        public void Hide()
        {
            _uiNavigator.HideAll();
        }

        public void Show()
        {
            _uiNavigator.Show<IMainMenu>();
        }
    }
}