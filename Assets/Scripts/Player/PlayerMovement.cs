using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction;
    public static bool pausePlayer;
    [SerializeField] SlotsManager _slotsManager;
    [SerializeField] private UI_Inventory _uiInventory;
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
        if (!_uiInventory.ShowInventory)
        {
            direction = context.ReadValue<Vector2>();
            return;
        }
        direction = Vector2.zero;
        if (context.started)
        {
            if (_slotsManager.IndexButton == -1) return;
            _slotsManager.Desappears();
            if (context.ReadValue<Vector2>() == Vector2.right && (_slotsManager.IndexButton + 1) % indexRaw != 0)
                _slotsManager.IndexButton++;
            else if (context.ReadValue<Vector2>() == Vector2.left && _slotsManager.IndexButton % indexRaw != 0)
                _slotsManager.IndexButton--;
            else if (context.ReadValue<Vector2>() == Vector2.up && _slotsManager.IndexButton - indexRaw >= 0)
                _slotsManager.IndexButton -= indexRaw;
            else if (context.ReadValue<Vector2>() == Vector2.down && _slotsManager.IndexButton + indexRaw < _slotsManager.transform.childCount)
                _slotsManager.IndexButton += indexRaw;
            if (_slotsManager.IndexButton < _slotsManager.inventory.Container.Count)
                _slotsManager.ShowTextInventory(_slotsManager.inventory.Container[_slotsManager.IndexButton].item.TextInv());
            Button[] buttons = _slotsManager.GetComponentsInChildren<Button>();
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
            Button[] buttons = _slotsManager.GetComponentsInChildren<Button>();
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
