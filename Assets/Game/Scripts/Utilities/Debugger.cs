using UnityEngine;

namespace Util
{
    public static class Debugger
    {
        public static void Log(object message)
        {
#if UNITY_EDITOR
            Debug.Log(message);
#endif
        }
    }
}
