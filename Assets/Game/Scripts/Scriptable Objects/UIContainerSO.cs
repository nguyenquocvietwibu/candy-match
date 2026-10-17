using UnityEngine;

[CreateAssetMenu(fileName = "UI Container SO", menuName = "Scriptable Objects/UI Container", order = 1)]
public class UIContainerSO : ScriptableObject
{
    [SerializeField] private float _horizontalPadding;
    [SerializeField] private float _verticalPadding;
    
    public float HorizontalPadding => _horizontalPadding;
    public float VerticalPadding => _verticalPadding;
}
