using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Views.World
{
    public class Board : MonoBehaviour
    {
        [SerializeField] private Tilemap _candyMap;
        [SerializeField] private Tilemap _cellMap;

        public Vector3Int Anchor => _candyMap.cellBounds.min;
        private void Awake()
        {
            _candyMap.gameObject.SetActive(false);
            _cellMap.CompressBounds();
            _candyMap.CompressBounds();
        }
        public void ForeachTile(Action<Vector3Int, Sprite> action)
        {
            BoundsInt candyMapBounds = _candyMap.cellBounds;
            BoundsInt cellMapBounds = _cellMap.cellBounds;

            foreach (Vector3Int cellPos in cellMapBounds.allPositionsWithin)
            {
                if (!_cellMap.HasTile(cellPos)) return;
                Vector3Int tilePos = cellPos;
                Sprite candySprite = _candyMap.GetSprite(tilePos);
                action?.Invoke(tilePos, candySprite);
            }
        }
    }
}
