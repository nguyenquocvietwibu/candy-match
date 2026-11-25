using System.Collections;
using System.Collections.Generic;


namespace Core
{
    public enum UIModalCategory
    {
        SettingsMenu,
        PauseMenu,
        TimeToReadyPopup,
        RestartConfirmationPopup,
        MainMenuConfirmationPopup
    }
    public class UIModalNavigator
    {
        private readonly HashSet<IView> _currentUIModalHashSet = new();
        private readonly List<IView> _currentUIModalList = new();
        private readonly Dictionary<UIModalCategory, IView> _uiModalViewDict;
        private readonly Dictionary<IView, int> _currentUIModalIndexDict = new();
        public UIModalNavigator(Dictionary<UIModalCategory, IView> uiModalViewDict)
        {
            _uiModalViewDict = uiModalViewDict;
            foreach (var pair in _uiModalViewDict)
            {
                pair.Value.Hide();
            }
        }
        public void Show(UIModalCategory uiModal)
        {
            IView uiModalView = _uiModalViewDict[uiModal];
            uiModalView.Show();
            bool isShowable = _currentUIModalHashSet.Add(uiModalView);
            if (!isShowable) return;
            _currentUIModalIndexDict.Add(uiModalView, _currentUIModalHashSet.Count - 1);
            _currentUIModalList.Add(uiModalView);
        }
        public void Hide(UIModalCategory uiModal)
        {
            IView uiModalView = _uiModalViewDict[uiModal];
            uiModalView.Hide();
            if (!_currentUIModalHashSet.Remove(uiModalView)) return;
            SwapBackToRemoveBy(uiModalView);

        }
        private void SwapBackToRemoveBy(IView uiModalToRemove)
        {
            int lastIndex = _currentUIModalList.Count - 1;
            int indexToRemove = _currentUIModalIndexDict[uiModalToRemove];
            if (indexToRemove != lastIndex)
            {
                IView lastMovedUIModal = _currentUIModalList[indexToRemove] = _currentUIModalList[lastIndex];
                _currentUIModalIndexDict[lastMovedUIModal] = indexToRemove;
            }
            _currentUIModalIndexDict.Remove(uiModalToRemove);
            _currentUIModalList.RemoveAt(lastIndex);
        }
        public void Clear()
        {

            for (int i = _currentUIModalList.Count - 1; i >= 0; i--)
            {
                IView uiModal = _currentUIModalList[i];
                uiModal.Hide();
                _currentUIModalIndexDict.Remove(uiModal);
                _currentUIModalHashSet.Remove(uiModal);
                _currentUIModalList.RemoveAt(i);
            }
        }
    }
}