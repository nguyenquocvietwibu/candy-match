using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Candy Database SO", menuName = "Scriptable Objects/Candy Database")]
public class CandyDatabase : ScriptableObject
{
    [SerializeField] private List<CandyEntry> _candyEntryList;
    [SerializeField] private Dictionary<Sprite, int> _candyTypeDict;
}