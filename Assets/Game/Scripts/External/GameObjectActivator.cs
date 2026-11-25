using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public static class GameObjectActivator
    {
        public static void ActiveChildrensFrom(Transform parent)
        {
            foreach (Transform children in parent.transform)
            {
                children.gameObject.SetActive(true);
                ActiveChildrensFrom(children);
            }
            
        }
    }
}