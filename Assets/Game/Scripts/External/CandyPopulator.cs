using System;
using System.Collections;
using UnityEngine;
using Views.World;

public class CandyPopulator
{
    private readonly Views.World.Board _boardPrefab;
    private readonly CandyDatabaseSO _candyDbSO;
    private readonly Models.Grid _cachedBoardGridModel = new(100, 100);
    private readonly IObjectPool<Candy> _candyPool;
    private readonly CandyManager _candyManager;
    public CandyPopulator(
        Views.World.Board boardPredab,
        CandyDatabaseSO candyDbSO,
        IObjectPool<Candy> candyPool,
        CandyManager candyManager)
    {
        _boardPrefab = boardPredab;
        _candyDbSO = candyDbSO;
        _candyPool = candyPool;
        _candyManager = candyManager;
    }
    public ReadOnlySpan<int> CreateCandyGridModel()
    {
        _boardPrefab.ForeachTile(SetupCandy);
        return _cachedBoardGridModel.AsReadOnlySpan();
    }
    private void SetupCandy(Vector3Int candyWorldCellPostition, Sprite candySprite)
    {
        Candy candy = _candyPool.Rent();
        candy.Sprite = candySprite;
        int candyTypeId = _candyDbSO.GetCandyTypeId(candySprite);
        _candyManager.Add(candyTypeId, candy);
        Vector3Int boardAnchor = _boardPrefab.Anchor;
        Vector2Int candyArrayCellPosition = new(
            candyWorldCellPostition.x - boardAnchor.x,
            candyWorldCellPostition.y - boardAnchor.y);
        _cachedBoardGridModel.SetElementId(candyArrayCellPosition.x, candyArrayCellPosition.y, candyTypeId);
        candy.transform.position = (Vector3)candyWorldCellPostition + new Vector3(0.5f, 0.5f, 0);
    }
}