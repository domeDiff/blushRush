using UnityEngine;

public class Tiles : MonoBehaviour
{
    public int tileType;
    public Vector2Int boardPosition;

    public void Setup(int type, Vector2Int position)
    {
        tileType = type;
        boardPosition = position;

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
}
