using UnityEngine;
using UnityEngine.EventSystems;
using Views.UI;
using Views.World;

[CreateAssetMenu(fileName = "Prefab Provider SO", menuName = "Scriptable Objects/Prefab Provider")]
public class PrefabProviderSO : ScriptableObject
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private GameUI _gameUIContainer;
    [SerializeField] private Board _board;
    [SerializeField] private Candy _candy;
    public Camera MainCamera => _mainCamera;
    public GameUI GameUIContainer => _gameUIContainer;
    public EventSystem EventSystem => _eventSystem;
    public Board Board => _board;
    public Candy Candy => _candy;
}