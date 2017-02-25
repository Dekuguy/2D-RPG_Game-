using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableCharacter : AttackableBase {

    [SerializeField]
    private int Lives = 3;

    public override void OnHit(ItemType item)
    {
        Lives--;
        if(Lives <= 0)
        {
            WorldFunktions.FreezeLivingMovement(true);
            GetComponentInChildren<SpriteRenderer>().enabled = false;
        }
    }
}
