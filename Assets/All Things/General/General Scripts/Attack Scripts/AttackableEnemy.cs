using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableEnemy : AttackableBase
{
    [SerializeField]
    private int Lives = 2;

    public override void OnHit(ItemType item)
    {
        Lives--;
        if (Lives > 0)
        {
            GetComponent<Bat>().MovementView.TakeHit();
        }
        else
        {
            GetComponent<Bat>().MovementView.Die();
            GetComponent<Bat>().MovementModel.SetCanMove(false);
            this.gameObject.layer = LayerMask.NameToLayer("NoCollision");
			Destroy();
        }
    }

}
