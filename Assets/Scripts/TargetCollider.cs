using UnityEngine;
using UnityEngine.UI;

public class TargetCollider : MonoBehaviour
{
    private string clickedButtonTag;
    private int points = 0;

    public Text pointsText; // Reference to a UI Text component to display points

    public void SetClickedButton(string buttonTag)
    {
        clickedButtonTag = buttonTag;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;

        if (otherObject.CompareTag(clickedButtonTag))
        {
            IncrementPoints();
        }
    }

    private void IncrementPoints()
    {
        points += 10;
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = points.ToString();
        }
    }
}
