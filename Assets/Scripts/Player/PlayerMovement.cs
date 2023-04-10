using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction;
    public static bool pausePlayer;
    [SerializeField] SlotsManager slotsManager;
    [SerializeField] private UI_Inventory uI_Inventory;
    public float SpeedPlayer { get; set; } = 5;
    [SerializeField] private Rigidbody2D rbPlayer;
    [SerializeField] private int indexRaw = 9;

    void Start()
    {
        PlayerStatistic.Instance.MoveSpeed = SpeedPlayer;
    }
    public void Move(InputAction.CallbackContext context)
    {
        if (pausePlayer) return;
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
            Button[] buttons = slotsManager.GetComponentsInChildren<Button>();
            StartCoroutine(WaitForNav());
            IEnumerator WaitForNav()
            {
                yield return new WaitForSeconds(0.2f);
                foreach (var button in buttons)
                {
                    Navigation StopNav = new Navigation();
                    StopNav.mode = Navigation.Mode.None;
                    button.navigation = StopNav;
                }
            }
        }
        else if (context.canceled)
        {
            StopAllCoroutines();
            Button[] buttons = slotsManager.GetComponentsInChildren<Button>();
            foreach (var button in buttons)
            {
                Navigation StopNav = new Navigation();
                StopNav.mode = Navigation.Mode.Automatic;
                button.navigation = StopNav;
            }
        }

    }
    void FixedUpdate()
    {
        rbPlayer.velocity = direction * PlayerStatistic.Instance.MoveSpeed;
    }
}
