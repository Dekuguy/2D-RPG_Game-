using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour {

    [SerializeField]
    private ItemType type;

    private void OnTriggerEnter2D(Collider2D ObjectCollision)
    {
        Debug.Log(ObjectCollision.name);
        AttackableBase Attackable = ObjectCollision.GetComponent<AttackableBase>();
        if (Attackable != null)
        {
            Attackable.OnHit(type);
        }
    }

}
