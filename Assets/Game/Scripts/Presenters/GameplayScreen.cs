namespace Presenter
{
    public class GameplayScreen : IView
    {
        private readonly IView _hudView;
        private readonly IView _gameplayBg;
        private readonly IViewNavigator _uiNavigator;
        public GameplayScreen(IView hudView, IViewNavigator uiNavigator, IView gameplayBgView)
        {
            _hudView = hudView;
            _uiNavigator = uiNavigator;
            _gameplayBg = gameplayBgView;
            _gameplayBg.Hide();
        }
        public void Hide()
        {
            _hudView.Hide();
            _gameplayBg.Hide();
            _uiNavigator.HideAll();
        }

        public void Show()
        {
            _gameplayBg.Show();
            _hudView.Show();
        }
    }

    //public class GameplayScreen : IView
    //{
    //    private readonly IView _hudView;
    //    private readonly IView _gameplayBg;
    //    private readonly IViewNavigator _uiNavigator;
    //    public GameplayScreen(IView hudView, IViewNavigator uiNavigator)
    //    {
    //        _hudView = hudView;
    //        _uiNavigator = uiNavigator;
    //    }
    //    public void Hide()
    //    {
    //        _hudView.Hide();
    //        _uiNavigator.HideAll();
    //    }

    //    public void Show()
    //    {
    //        _hudView.Show();
    //    }
    //}
}