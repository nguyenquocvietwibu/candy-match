using UnityEngine;
using UnityEngine.EventSystems;
using View.Overlay;

[CreateAssetMenu(fileName = "Prefab Provider SO", menuName = "Scriptable Objects/Prefab Provider")]
public class PrefabProviderSO : ScriptableObject
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private UI _ui;
    [SerializeField] private ScreenFader _screenFader;
    [SerializeField] private GameplayBg _gamePlayBg;
    public Camera MainCamera => _mainCamera;
    public UI UI => _ui;
    public ScreenFader ScreenFader => _screenFader;
    public EventSystem EventSystem => _eventSystem;
    public GameplayBg GameplayBg => _gamePlayBg;
}