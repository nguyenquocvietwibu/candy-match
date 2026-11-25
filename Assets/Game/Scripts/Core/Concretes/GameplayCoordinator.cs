using System;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace Core
{
    public class GameplayCoordinator
    {
        private SceneCoordinator _sceneCoordinator;
        private ITimeToReadyPopup _timeToReadyPopup;
        private IPauseMenu _pauseMenu;
        private IConfirmationPopup _restartConfirmationPopup;
        private IConfirmationPopup _mainMenuConfirmationPopup;
        private IWorldTimeService _worldTimeService;
        private IHUD _hud;
        private CancellationTokenSource _tokenSource = new();
        public GameplayCoordinator(
            SceneCoordinator sceneCoordinator,
            ITimeToReadyPopup timeToReadyPopup,
            IPauseMenu pauseMenu,
            IConfirmationPopup restartConfirmationPopup,
            IConfirmationPopup mainMenuConfirmationPopup,
            IWorldTimeService worldTimeService,
            IHUD hud)
        {
            _mainMenuConfirmationPopup = mainMenuConfirmationPopup;
            _hud = hud;
            _worldTimeService = worldTimeService;
            _restartConfirmationPopup = restartConfirmationPopup;
            _pauseMenu = pauseMenu;
            _sceneCoordinator = sceneCoordinator;
            _timeToReadyPopup = timeToReadyPopup;

            _sceneCoordinator.ChangedToGameplayScene += OnChangedToGameplayScene;
            _sceneCoordinator.ChangingToGameplayScene += OnChangingToGameplayScene;
            _hud.PauseButtonClicked += OnPauseClicked;
            _restartConfirmationPopup.ConfirmButtonClicked += OnChangeSceneConfirmClicked;
            _mainMenuConfirmationPopup.ConfirmButtonClicked += OnChangeSceneConfirmClicked;
            _pauseMenu.ResumeButtonClicked += OnResumeClicked;
        }

        private void OnResumeClicked()
        {
            ResumeTime();
        }

        private void OnChangeSceneConfirmClicked()
        {
            ResumeTime();
            _tokenSource.Cancel();
        }

        private void OnPauseClicked()
        {
            _worldTimeService.Pause();
        }

        private void OnChangingToGameplayScene()
        {
            _timeToReadyPopup.SetDefault();
        }
        private async void OnChangedToGameplayScene()
        {
            try
            {
                await _timeToReadyPopup.CountDownAsync(GetValidCountDownToken());
            }
            catch (OperationCanceledException) { }
        }

        private CancellationToken GetValidCountDownToken()
        {
            if (_tokenSource != null &&
                !_tokenSource.IsCancellationRequested) return _tokenSource.Token;
            _tokenSource.Dispose();
            _tokenSource = new();
            return _tokenSource.Token;
        }

        private void ResumeTime()
        {
            _worldTimeService.Resume();
        }
    }
}