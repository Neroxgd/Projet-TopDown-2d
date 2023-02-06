using UnityEngine;

public class SelectObject : MonoBehaviour
{
    private GetReferenceForButton RefButton;

    void Start()
    {
        RefButton = transform.parent.parent.GetComponent<GetReferenceForButton>();
    }

    public void InitializeIndex()
    {
        for (int i = 0; i < RefButton.inventory.Container.Count; i++)
        {
            if (transform.parent.parent.GetChild(i) == transform.parent)
            {
                RefButton.IndexButton = i;
                RefButton.TextDropItem(true);
                break;
            }
            else
            {
                RefButton.IndexButton = -1;
                RefButton.TextDropItem(false);
            }
        }
    }
}
