
using System.Collections.Generic;
using System;
namespace Presenter
{
    public class ViewNavigator : IViewNavigator
    {
        private readonly Dictionary<Type, IView> _viewTypeDict = new();
        private readonly Stack<IView> _viewStack = new();
        private IView _activeView;
        public void Register<T>(IView view)
        {
            _viewTypeDict[typeof(T)] = view;
            view.Hide();
        }
        public void Show<T>()
        {
            IView view = GetViewBy<T>();
            view.Show();
            if (_activeView != null) _viewStack.Push(_activeView);
            _activeView = view;
        }
        public void Hide<T>()
        {
            GetViewBy<T>().Hide();
        }

        public void ShowPrevious()
        {
            _activeView = _viewStack.Pop();
            _activeView.Show();
        }
        private IView GetViewBy<T>()
        {
            return _viewTypeDict[typeof(T)];
        }

        public void HideAll()
        {
            if (_activeView != null)
            {
                _activeView.Hide();
                _activeView = null;
            }
            while (_viewStack.Count > 0) _viewStack.Pop().Hide();
        }
    }
}