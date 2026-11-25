using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views.UI
{
    public class SettingsMenu : MonoBehaviour, ISettingsMenu
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _sfxSlider;
        [SerializeField] private Slider _musicSlider;

        [SerializeField] private Toggle _sfxToggle;
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _30FPSToggle;
        [SerializeField] private Toggle _60FPSToggle;
        [SerializeField] private Toggle _120FPSToggle;
        [SerializeField] private View _view;
        public View View => _view;

        public event Action BackButtonClicked;

        private void Awake()
        {
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            BackButtonClicked?.Invoke();
        }
    }
}

