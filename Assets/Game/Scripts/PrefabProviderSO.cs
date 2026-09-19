using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "Prefab Provider SO", menuName = "Scriptable Objects/Prefab Provider")]
public class PrefabProviderSO : ScriptableObject
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private EventSystem _eventSystem;
    public Camera MainCamera => _mainCamera;
    public Canvas UICanvas => _uiCanvas;
    public EventSystem EventSystem => _eventSystem;
}