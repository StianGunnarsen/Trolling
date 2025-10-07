using UnityEngine;

public class LockStage : MonoBehaviour
{
    public GameObject movingBox;
    public GameObject targetZone;
    public SpriteRenderer columnVisual;
    public Color normalColor = Color.white;
    public Color activeColor = Color.yellow;
    public Color successColor = Color.green;

    private bool isComplete = false;

    public bool CheckLock()
    {
        if (isComplete) return false;

        Collider2D boxCol = movingBox.GetComponent<Collider2D>();
        Collider2D targetCol = targetZone.GetComponent<Collider2D>();

        if (boxCol.bounds.Intersects(targetCol.bounds))
        {
            isComplete = true;
            movingBox.GetComponent<LockpicBoxMover>().enabled = false;
            columnVisual.color = successColor;
            return true;
        }

        return false;
    }

    public void SetHighlight(bool active)
    {
        if (isComplete)
        {
            columnVisual.color = successColor;
        }
        else
        {
            columnVisual.color = active ? activeColor : normalColor;
        }
    }

    public void ResetStage()
    {
        isComplete = false;
        columnVisual.color = normalColor;
        movingBox.GetComponent<LockpicBoxMover>().enabled = true;
    }
}
