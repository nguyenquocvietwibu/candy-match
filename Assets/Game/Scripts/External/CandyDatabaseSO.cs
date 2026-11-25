using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

[CreateAssetMenu(fileName = "Candy Database SO", menuName = "Scriptable Objects/Candy Database")]
public class CandyDatabaseSO : ScriptableObject
{
    [FormerlySerializedAs("_candyTypeDict")]
    [SerializeField]
    [DictionaryDisplay(keyLabel = "Type id", valueLabel = "View", keyColumnFraction = 0.6f)]
    private Dictionary<int, Sprite> _candyTypeDict;
    private List<int> _candyTypeIdList = new();
    private Dictionary<Sprite, int> _typeCandyDict = new();

    private void OnEnable()
    {
        foreach (KeyValuePair<int, Sprite> candyTypePair in _candyTypeDict)
        {
            _candyTypeIdList.Add(candyTypePair.Key);
            _typeCandyDict[candyTypePair.Value] = candyTypePair.Key;
        }
    }
    public Sprite GetCandySprite(int typeId, out Sprite candySprite)
    {
        if (!_candyTypeDict.TryGetValue(typeId, out candySprite)) throw new System.Exception("Cannot get candy sprite");
        return candySprite;
    }
    public int GetCandyTypeId(Sprite candySprite)
    {
        if (!_typeCandyDict.TryGetValue(candySprite, out int typeId)) throw new System.Exception("Cannot get candy type id");
        return typeId;
    }
    public int GetRandomTypeId()
    {
        return _candyTypeIdList[Random.Range(0, _candyTypeIdList.Count - 1)];
    }

}