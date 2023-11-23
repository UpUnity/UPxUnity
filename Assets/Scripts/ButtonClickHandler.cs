using UnityEngine;
using UnityEngine.UI;

public class ButtonClickHandler : MonoBehaviour
{
    public string buttonTag;

    public void OnButtonClick()
    {
        TargetCollider targetCollider = FindObjectOfType<TargetCollider>();

        if (targetCollider != null)
        {
            targetCollider.SetClickedButton(buttonTag);
        }
    }
}
