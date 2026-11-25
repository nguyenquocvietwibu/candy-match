using System;
using System.Collections;
using System.Collections.Generic;

namespace Core
{
    public enum ConfirmationPopupCategory
    {
        Restart,
        MainMenu,
    }
    public class ConfirmationPopupNavigator
    {
        private ConfirmationPopupBinder[] _popupViewBinderArray;
        public ConfirmationPopupNavigator(
            Dictionary<IConfirmationPopup, IView> confirmationPopupViewDict)
        {
            _popupViewBinderArray = new ConfirmationPopupBinder[confirmationPopupViewDict.Count];
            int currentIndex = 0;
            foreach (var pair in confirmationPopupViewDict)
            {
                IView view = pair.Value;
                ConfirmationPopupBinder popupViewBinder = new(pair.Key, view);
                popupViewBinder.Attach();
                _popupViewBinderArray[currentIndex] = popupViewBinder;
                view.Hide();
            }
        }
        private class ConfirmationPopupBinder
        {
            private IConfirmationPopup _popup;
            private IView _view;
            public ConfirmationPopupBinder(IConfirmationPopup popup, IView view)
            {
                _popup = popup;
                _view = view;
            }

            public void Attach()
            {
                _popup.CancelButtonClicked += OnCancelButtonClicked;
            }
            public void Detach()
            {
                _popup.CancelButtonClicked -= OnCancelButtonClicked;
            }

            private void OnCancelButtonClicked()
            {
                _view.Hide();
            }
        }
    }
}

