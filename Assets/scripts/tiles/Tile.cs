using UnityEngine;

public class Tile : MonoBehaviour
{
    public int tileType;
    public Vector2Int boardPosition;
    private BoardManager boardManager;

    private Vector3 originalScale;

    public void Setup(int type, Vector2Int position, BoardManager manager)
    {
        tileType = type;
        boardPosition = position;
        boardManager = manager;

        originalScale = transform.localScale;

        SetColor();
    }

    private void SetColor()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        switch (tileType)
        {
            case 0:
                spriteRenderer.color = Color.magenta; break;

            case 1:
                spriteRenderer.color = Color.cyan; break;

            case 2:
                spriteRenderer.color = Color.pink; break;

            case 3:
                spriteRenderer.color = Color.violet; break;

            case 4:
                spriteRenderer.color = Color.red; break;

            case 5:
                spriteRenderer.color = Color.yellowNice; break;

        }
    }

    private void OnMouseDown()
    {
        boardManager.SelectTile(this);
    }

    public void SetSelected(bool selected)
    {
        if (selected)
        {
            transform.localScale = originalScale * 1.1f;
        }
        else
        {
            transform.localScale = originalScale;
        }
    }
}
