using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace View.World
{
    public class Board : View
    {
        [SerializeField] private Tilemap _candyMap;
        [SerializeField] private Tilemap _cellMap;

        private void Awake()
        {
            _candyMap.gameObject.SetActive(false);
            _cellMap.CompressBounds();
            _candyMap.CompressBounds();
        }
        public void ForeachCell(Action<Vector3Int, Sprite> callback)
        {
            BoundsInt candyMapBounds = _candyMap.cellBounds;
            BoundsInt cellMapBounds = _cellMap.cellBounds;

            foreach (Vector3Int cellPos in cellMapBounds.allPositionsWithin)
            {
                Vector3Int tileCellPos;
                if (!_cellMap.HasTile(cellPos)) return;
                tileCellPos = cellPos;
                Sprite candySprite = _candyMap.GetSprite(tileCellPos);
                callback?.Invoke(tileCellPos, candySprite);
            }
        }
    }
}
