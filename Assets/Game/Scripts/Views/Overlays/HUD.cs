using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.Overlay
{
    public class HUD : View, IHUD
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private TextMeshProUGUI _timeLeftTMP;
        [SerializeField] private Slider _timeLeftSlider;

        public event Action PauseButtonClicked;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        }

        private void OnPauseButtonClicked()
        {
            PauseButtonClicked?.Invoke();
        }
    }
}


