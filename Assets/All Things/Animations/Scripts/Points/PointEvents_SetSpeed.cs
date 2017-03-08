using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvents_SetSpeed : PointEvents_Base {
	[SerializeField]
	private float speed = 1;

	public override void Triggered()
	{
		GetComponentInParent<AnimationTrigger>().Speed = speed;

		base.Triggered();
	}
}
