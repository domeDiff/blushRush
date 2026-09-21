using UnityEngine;

public class BoardManager: MonoBehaviour
{
    [SerializeField] private int width = 8;
    [SerializeField] private int height = 8;

    private int[,] board;

    private void Start()
    {
        CreateBoard();
    }

    private void CreateBoard()
    {
        board = new int[width, height];

        for(int x=0; x < width; x++)
        {
            for(int y=0; y < height; y++)
            {
                board[x, y] = Random.Range(0, 6);
            }
        }

        Debug.Log("AMORE board created: " + width + "x" + height);
    }
}