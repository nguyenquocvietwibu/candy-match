namespace Presenter
{
    public class TitleScreen : IView
    {
        private readonly IView _mainMenuView;
        public TitleScreen(IView mainMenuView)
        {
            _mainMenuView = mainMenuView;
        }
        public void Hide()
        {
            _mainMenuView.Hide();
        }

        public void Show()
        {
            _mainMenuView.Show();
        }
    }
}