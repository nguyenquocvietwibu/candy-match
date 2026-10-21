using System;
using UnityEngine;
using UnityEngine.UI;

namespace View.Overlay
{
    public class SettingsMenu : View, ISettingsMenu
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Slider _sfxSlider;
        [SerializeField] private Slider _musicSlider;

        [SerializeField] private Toggle _sfxToggle;
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _30FPSToggle;
        [SerializeField] private Toggle _60FPSToggle;
        [SerializeField] private Toggle _120FPSToggle;

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

