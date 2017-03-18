using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableBase : MonoBehaviour
{
    public virtual void OnHit(ItemType item)
    {
        Debug.LogWarning("No Onhit event Setup: " + gameObject.name, gameObject);
    }
	protected void Destroy()
	{
		SendMessage("GameObjectDestroyed");
	}
}
