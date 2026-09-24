using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private int width = 8;
    [SerializeField] private int height = 8;
    [SerializeField] private float tileSize = 1f;
    [SerializeField] private Tile tilePrefab;

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

                tile.Setup(tileType, new Vector2Int(x, y));

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
}

