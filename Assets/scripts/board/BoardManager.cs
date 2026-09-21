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

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int tileType = Random.Range(0, 6);

                Vector3 worldPosition = new Vector3(
                    x * tileSize,
                    y * tileSize,
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
}