using System.Numerics;
using UnityEngine;

namespace Utils
{
    public static class GridConverter
    {
        public static Vector2Int WorldCellToArrayCell(Vector3Int worldCellPosition, Vector3Int worldGridAnchor)
        {
            return new Vector2Int(worldCellPosition.x - worldGridAnchor.x, worldCellPosition.y - worldGridAnchor.y);
        }
        public static Vector2Int ArrayCellToWorldCell(Vector3Int worldCellPosition, Vector3Int worldGridAnchor)
        {
            return new Vector2Int(worldCellPosition.x + worldGridAnchor.x, worldCellPosition.y + worldGridAnchor.y);
        }
    }
}