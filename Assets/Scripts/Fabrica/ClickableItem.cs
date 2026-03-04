using UnityEngine;

public class ClickableItem : MonoBehaviour, IDClickable
{
    public void OnClick()
    {
        Debug.Log("Clickao");
    }
}
