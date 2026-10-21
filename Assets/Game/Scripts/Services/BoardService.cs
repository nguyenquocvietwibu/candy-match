using View.World;
using Model;
using UnityEngine;
public class BoardService
{
    private readonly Board _boardPrefab;
    private readonly Candy _candyPrefab;
    private Model.Grid _boardModel = new();
    public BoardService(Board boardPrefab, Candy candyPrefab)
    {
        _boardPrefab = boardPrefab;
        _candyPrefab = candyPrefab;
    }
    public Model.Grid LoadBoardModel()
    {
        _boardPrefab.ForeachCell(OnCellTraversal);
        return _boardModel;
    }

    public void Generate()
    {
        
    }
    private void OnCellTraversal(Vector3Int cellPos, Sprite candySprite)
    {

    }
}
