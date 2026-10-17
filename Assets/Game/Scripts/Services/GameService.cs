using UnityEngine;

public class GameService
{
    public void Quit()
    {
        Debug.Log("Quit!");
#if UNITY_EDITOR
        //UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
