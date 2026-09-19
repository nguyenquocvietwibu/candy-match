using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private PrefabProviderSO _prefabProviderSO;
    private void Awake()
    {
        if (_prefabProviderSO == null)
        {
            throw new System.Exception("PrefabProviderSO is not assigned in the inspector.");
        }
    }

    private void Start()
    {
        Init().Forget();
    }

    private async UniTaskVoid Init()
    {
        Camera mainCamera = Instantiate(_prefabProviderSO.MainCamera);
        EventSystem eventSytem = Instantiate(_prefabProviderSO.EventSystem);
        Canvas uiCanvas = Instantiate(_prefabProviderSO.UICanvas);

        UI ui = new UI(uiCanvas, mainCamera);

        await UniTask.Yield();
    }
}
