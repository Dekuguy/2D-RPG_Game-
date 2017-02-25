using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvents_Wait : PointEvents_Base {

	[SerializeField]
	private float time;

	private bool isTriggered;
	private float timeduration;

	void Start()
	{
		finished = false;
	}

	public override void Triggered()
	{
		isTriggered = true;
		base.Triggered();
	}

	void Update()
	{
		if (isTriggered)
		{
			timeduration += Time.deltaTime;
			if(timeduration >= time)
			{
				finished = true;
			}
		}
	}
}
