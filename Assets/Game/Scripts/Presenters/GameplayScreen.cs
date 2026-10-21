namespace Presenter
{
    public class GameplayScreen : IView
    {
        private readonly IView _hudView;
        private readonly IView _gameplayBg;
        private readonly IView _boardView;
        public GameplayScreen(IView hudView, IView gameplayBgView, IView boardView)
        {
            _hudView = hudView;
            _gameplayBg = gameplayBgView;
            _boardView = boardView;

            _gameplayBg.Hide();
            _hudView.Hide();
            _boardView.Hide();
        }
        public void Hide()
        {
            _hudView.Hide();
            _gameplayBg.Hide();
        }

        public void Show()
        {
            _gameplayBg.Show();
            _hudView.Show();
            _boardView.Show();
        }
    }
}