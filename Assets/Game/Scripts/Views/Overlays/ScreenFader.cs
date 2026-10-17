using Cysharp.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenFader : MonoBehaviour, IFader
{
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField, Min(0f)] private float _fadeDuration = 1f;
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.interactable = false;
    }

    public async UniTask FadeInAsync()
    {
        await FadeToAsync(0);
        _canvasGroup.blocksRaycasts = false;

    }

    public async UniTask FadeOutAsync()
    {
        _canvasGroup.blocksRaycasts = true;
        await FadeToAsync(1); 
    }

    private async UniTask FadeToAsync(float targetAlpha)
    {
        targetAlpha = Mathf.Clamp01(targetAlpha);
        float currentAlpha = _canvasGroup.alpha;
        float elapsedTime = 0f;
        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / _fadeDuration);
            _canvasGroup.alpha = Mathf.Lerp(currentAlpha, targetAlpha, progress);
            await UniTask.NextFrame();
        }
        _canvasGroup.alpha = targetAlpha;
    }

    Task IFader.FadeInAsync()
    {
        return FadeInAsync().AsTask();
    }

    Task IFader.FadeOutAsync()
    {
        return FadeOutAsync().AsTask();
    }
}
