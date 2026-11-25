using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class HUD : MonoBehaviour, IHUD
    {
        [SerializeField] private Button _pauseButton;
        [SerializeField] private TextMeshProUGUI _scoreTextGUI;
        [SerializeField] private TextMeshProUGUI _timeLeftTextGUI;
        [SerializeField] private Slider _timeLeftSlider;
        [SerializeField] private View _view;
        public View View => _view;
        public event Action PauseButtonClicked;

        private void Awake()
        {
            _pauseButton.onClick.AddListener(() => PauseButtonClicked?.Invoke());
        }
    }
}


