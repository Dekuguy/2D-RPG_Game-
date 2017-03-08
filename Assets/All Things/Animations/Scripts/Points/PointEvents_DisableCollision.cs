using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvents_DisableCollision : PointEvents_Base {

	public override void Triggered()
	{
		GetComponentInParent<AnimationTrigger>().prefab.GetComponent<Collider2D>().enabled = false;

		base.Triggered();
	}
}
