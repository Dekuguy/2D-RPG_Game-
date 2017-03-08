using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerBase : MonoBehaviour {
	[SerializeField]
	protected int TriggerID = 0;
	[SerializeField]
	protected List<AnimationTrigger> triggers;

	protected void TriggerStart()
	{
		foreach (AnimationTrigger t in triggers)
		{
			t.TriggerAnimation(TriggerID);
		}
		TriggerID++;
	}
}
