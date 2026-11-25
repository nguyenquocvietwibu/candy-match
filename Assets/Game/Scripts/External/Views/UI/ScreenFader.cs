using Cysharp.Threading.Tasks;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ScreenFader : MonoBehaviour, IFader
{
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField, Min(0f)] private float _fadeDuration = 1f;
    private void Awake()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = false;
    }

    private async UniTask FadeInInternalAsync()
    {
        await FadeToAsync(0);
        _canvasGroup.blocksRaycasts = false;
    }

    private async UniTask FadeOutInternalAsync()
    {
        _canvasGroup.blocksRaycasts = true;
        await FadeToAsync(1); 
    }

    private async UniTask FadeToAsync(float targetAlpha)
    {
        if (Mathf.Approximately(_canvasGroup.alpha, targetAlpha)) return;
        targetAlpha = Mathf.Clamp01(targetAlpha);
        float currentAlpha = _canvasGroup.alpha;
        float elapsedTime = 0f;
        while (elapsedTime < _fadeDuration)
        {
            float progress = Mathf.Clamp01(elapsedTime / _fadeDuration);
            _canvasGroup.alpha = Mathf.Lerp(currentAlpha, targetAlpha, progress);
            elapsedTime += Time.unscaledDeltaTime;
            await UniTask.NextFrame();
        }
        _canvasGroup.alpha = targetAlpha;
    }

    public ValueTask FadeInAsync()
    {
        //return FadeInInternalAsync().AsValueTask();
        return FadeInInternalAsync();
    }

    public ValueTask FadeOutAsync()
    {
        return FadeOutInternalAsync();
    }
}
