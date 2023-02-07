using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] private UI_Inventory uI_Inventory;
    [SerializeField][Range(1, 200)] private int speed = 1;
    [SerializeField] private Rigidbody2D rbPlayer;
    public void Move(InputAction.CallbackContext context)
    {
        if (!uI_Inventory.ShowInventory)
            direction = context.ReadValue<Vector2>();
        else 
            direction = Vector2.zero;
    }
    void FixedUpdate()
    {
        rbPlayer.velocity = direction * speed;
    }
}
