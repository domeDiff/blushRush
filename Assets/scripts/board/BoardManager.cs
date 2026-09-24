using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int width = 8;
    [SerializeField] private int height = 8;
    [SerializeField] private float tileSize = 1f;
    [SerializeField] private Tile tilePrefab;

    private Tile selectedTile;
    private Tile[,] board;

    private void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        board = new Tile[width, height];

        float startX = -(width - 1) * tileSize / 2f;
        float startY = -(height - 1) * tileSize / 2f;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int tileType = GetValidTileType(x, y);

                Vector3 worldPosition = new Vector3(
                    startX + x * tileSize,
                    startY + y * tileSize,
                    0f
                );

                Tile tile = Instantiate(
                    tilePrefab,
                    worldPosition,
                    Quaternion.identity,
                    transform
                );

                tile.Setup(tileType, new Vector2Int(x, y), this);

                board[x, y] = tile;
            }
        }
    }

    private int GetValidTileType(int x, int y)
    {
        int tileType;

        do
        {
            tileType = Random.Range(0, 6);
        }

        while (CreatesMatch(x, y, tileType));

        return tileType;
    }

    private bool CreatesMatch(int x, int y, int tileType)
    {
        if(x >= 2)
        {
            if (board[x-1, y].tileType == tileType && board[x-2, y].tileType == tileType)
            {
                return true;
            }
        }

        if(y >= 2)
        {
            if (board[x, y-1].tileType == tileType && board[x, y-2].tileType == tileType)
            {
                return true;
            }
        }

        return false;
    }

    public void SelectTile(Tile tile)
    {
        if(selectedTile == null)
        {
            selectedTile = tile;

            Debug.Log("selected: " + tile.boardPosition);
            return;
        }

        if(tile == selectedTile)
        {
            selectedTile = null;
            return;
        }

        if(AreAdjacent(selectedTile, tile))
        {
            SwapTiles(selectedTile, tile);
            return;
        }

        else
        {
            selectedTile = tile;
            Debug.Log("selected: " + tile.boardPosition);
        }
    }

    private bool AreAdjacent(Tile first, Tile second)
    {
        int distanceX = Mathf.Abs(first.boardPosition.x - second.boardPosition.x);
        int distanceY = Mathf.Abs(first.boardPosition.y - second.boardPosition.y);

        return distanceX + distanceY == 1;
    }

    private void SwapTiles(Tile first, Tile second)
    {
        Vector2Int firstPosition = first.boardPosition;
        Vector2Int secondPosition = second.boardPosition;

        board[firstPosition.x, firstPosition.y] = second;
        board[secondPosition.x, secondPosition.y] = first;

        first.boardPosition = secondPosition;
        second.boardPosition = firstPosition;

        first.transform.position = GetWorldPosition(secondPosition);
        second.transform.position = GetWorldPosition(firstPosition);

        selectedTile = null;
    }

    private Vector3 GetWorldPosition(Vector2Int position)
    {
        float startX = -(width - 1) * tileSize / 2f;
        float startY = -(height - 1) * tileSize / 2f;

        return new Vector3(startX + position.x * tileSize, startY + position.y * tileSize, 0f);
    }
}

