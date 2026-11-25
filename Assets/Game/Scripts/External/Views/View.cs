using System;
using UnityEngine;
namespace Views
{
    public class View : MonoBehaviour, IView
    {
        public event Action Showed;
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        public void Show()
        {
            gameObject.SetActive(true);
            Showed?.Invoke();
        }
    }
}