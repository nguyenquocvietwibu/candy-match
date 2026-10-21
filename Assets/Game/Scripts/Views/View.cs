using UnityEngine;
namespace View
{
    public class View : MonoBehaviour, IView
    {
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
    }
}
