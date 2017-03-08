using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvents_ResetAnimationPoint : MonoBehaviour {

	PointEvents_Base t;
	private bool isFinished = false;

	void Start()
	{
		bool hasMaster = false;
		foreach (PointEvents_Base p in GetComponents<PointEvents_Base>())
		{
			if (p.isMainEvent())
			{
				hasMaster = true;
				t = p;
			}
		}
		if (!hasMaster)
		{
			t = GetComponent<PointEvents_Base>();
		}
	}

	void Update()
	{
		if (t.isFinished() && !isFinished)
		{
			isFinished = true;
			GeneralAnimationState.Animationstatus = 0;
		}
	}
}
