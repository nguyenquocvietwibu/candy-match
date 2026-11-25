using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Views.World;

public class CandyManager
{
    private HashSet<Candy> _candyHashSet = new();
    private Dictionary<int, HashSet<Candy>> _candiesTypeIdDict = new();

    public void Add(int typeId, Candy candy)
    {
        _candyHashSet.Add(candy);
        if (_candiesTypeIdDict.TryGetValue(typeId, out HashSet<Candy> candyHashSet))
        {
            candyHashSet.Add(candy);
            Debug.Log(_candiesTypeIdDict[typeId].Count);
        }
        
    }
    public void Remove(int typeId, Candy candy)
    {
        _candyHashSet.Remove(candy);
        if (_candiesTypeIdDict.TryGetValue(typeId, out HashSet<Candy> candyHashSet))
        {
            candyHashSet.Remove(candy);
            Debug.Log(_candiesTypeIdDict[typeId].Count);
        }

    }
}