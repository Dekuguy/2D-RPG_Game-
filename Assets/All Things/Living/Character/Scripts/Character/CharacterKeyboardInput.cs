using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterKeyboardInput : CharacterBaseControl {

    void Update()
    {
        UpdateDirection();
        UpdateAttack();
        UpdateInteraction();
    }

    private void UpdateDirection()
    {
        Vector2 newDirection = Vector2.zero;

        newDirection.y = Input.GetAxisRaw("Vertical");
        newDirection.x = Input.GetAxisRaw("Horizontal");

        SetDirection(newDirection);
    }
    private void UpdateAttack()
    {
        if(Input.GetButtonDown("Attack"))
            OnAttackPressed();
    }
    private void UpdateInteraction()
    {
        if (Input.GetButtonDown("Interact"))
        {
            OnInteractPressed();
        }
    }
}
