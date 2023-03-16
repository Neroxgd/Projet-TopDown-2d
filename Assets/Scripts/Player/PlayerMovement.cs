using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] SlotsManager slotsManager;
    [SerializeField] private UI_Inventory uI_Inventory;
    [SerializeField, Range(1, 200)] private int speed = 1;
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private int indexRaw = 9;
    public void Move(InputAction.CallbackContext context)
    {
        if (!uI_Inventory.ShowInventory)
        {
            direction = context.ReadValue<Vector2>();
            return;
        }
        direction = Vector2.zero;
        if (context.started)
        {
            if (slotsManager.IndexButton == -1) return;
            slotsManager.Desappears();
            if (context.ReadValue<Vector2>() == Vector2.right && (slotsManager.IndexButton + 1) % indexRaw != 0)
                slotsManager.IndexButton++;
            else if (context.ReadValue<Vector2>() == Vector2.left && slotsManager.IndexButton % indexRaw != 0)
                slotsManager.IndexButton--;
            else if (context.ReadValue<Vector2>() == Vector2.up && slotsManager.IndexButton - indexRaw >= 0)
                slotsManager.IndexButton -= indexRaw;
            else if (context.ReadValue<Vector2>() == Vector2.down && slotsManager.IndexButton + indexRaw < slotsManager.transform.childCount)
                slotsManager.IndexButton += indexRaw;
            if (slotsManager.IndexButton < slotsManager.inventory.Container.Count)
                slotsManager.ShowTextInventory(slotsManager.inventory.Container[slotsManager.IndexButton].item.TextInv());
        }
    }
    void FixedUpdate()
    {
        rbPlayer.velocity = direction * speed;
    }
}
