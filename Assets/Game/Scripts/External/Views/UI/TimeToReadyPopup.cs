using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Views.UI
{
    public class TimeToReadyPopup : MonoBehaviour, ITimeToReadyPopup
    {
        [SerializeField] private TextMeshProUGUI _textGUI;
        [SerializeField] private string _defaultText;
        [SerializeField] private int _timeToReadyNumber = 3;
        [SerializeField] private View _view;
        public View View => _view;
        private async UniTask CountDownInternalAsync(CancellationToken token)
        {
            _view.Show();
            int currentTimeToReady = _timeToReadyNumber;
            while (currentTimeToReady > 0)
            {
                SetTime(currentTimeToReady);
                int timeStep = 1;
                await UniTask.Delay(TimeSpan.FromSeconds(timeStep), cancellationToken: token);
                currentTimeToReady -= timeStep;
            }
            _view.Hide();
        }

        public void SetDefault()
        {
            _textGUI.SetText(_defaultText);
        }

        private void SetTime(int value)
        {
            _textGUI.SetText("{0}", value);
        }

        private void Awake()
        {
            _defaultText = _textGUI.text;
        }
        private void OnValidate()
        {
            _defaultText = _textGUI.text;
        }


        public ValueTask CountDownAsync(CancellationToken token)
        {
            return CountDownInternalAsync(token);
        }
    }
}
