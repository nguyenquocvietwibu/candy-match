using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class ConfirmationPopup : MonoBehaviour, IConfirmationPopup
    {
        public event Action ConfirmButtonClicked;
        public event Action CancelButtonClicked;

        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private View _view;
        public View View => _view;

        private void Awake()
        {
            _confirmButton.onClick.AddListener(() => ConfirmButtonClicked?.Invoke());
            _cancelButton.onClick.AddListener(() => CancelButtonClicked?.Invoke());
        }
    }
}