using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CandyEntry
{
    [SerializeField] private Sprite _view;
    private int _typeId;
    public int TypeId => _typeId;
}