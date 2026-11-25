using System.Collections.Generic;

namespace Core
{
    public class ViewGroup : IView
    {
        private HashSet<IView> _viewHashSet;
        public ViewGroup(HashSet<IView> viewHashset)
        {
            _viewHashSet = viewHashset;
        }

        public void Hide()
        {
            foreach (IView view in _viewHashSet) view.Hide();
        }
        public void Show()
        {
            foreach (IView view in _viewHashSet) view.Show();
        }

    }
}