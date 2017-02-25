using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvents_LookDirection : PointEvents_Base {
	[SerializeField]
	private Vector2 direction;

	public override void Triggered()
	{
		GetComponentInParent<AnimationTrigger>().prefab.GetComponent<BaseMovementModel>().SetFacingDirection(direction);
		base.Triggered();
	}

}
