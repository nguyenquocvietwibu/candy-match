using UnityEngine;

public class UI
{
    private Canvas _canvas;

    public UI(Canvas canvas, Camera mainCamera)
    {
        _canvas = canvas;
        _canvas.worldCamera = mainCamera;
    }
}
