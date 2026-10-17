using System;
using UnityEngine;

namespace View.Overlay
{
    [RequireComponent(typeof(CanvasGroup))]
    public class View : MonoBehaviour, IView
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        protected CanvasGroup CanvasGroup => _canvasGroup;

        protected virtual void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        protected virtual void OnAwaken() { }
        public virtual void Show()
        {
            _canvasGroup.alpha = 1f;
            EnableInteraction();
        }
        public virtual void Hide()
        {
            _canvasGroup.alpha = 0f;
            DisableInteraction();
        }

        protected void EnableInteraction()
        {
            SetInteraction(true);
            enabled = true;
            gameObject.SetActive(true);
        }
        protected void DisableInteraction()
        {
            SetInteraction(false);
            enabled = false;
        }

        protected void SetInteraction(bool isInteractable)
        {
            _canvasGroup.interactable = isInteractable;
            _canvasGroup.blocksRaycasts = isInteractable;
        }

        protected virtual void Reset()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

    }

}
