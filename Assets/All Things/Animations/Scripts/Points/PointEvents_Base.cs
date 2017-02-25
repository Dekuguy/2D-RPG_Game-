using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointEvents_Base : MonoBehaviour {

	[SerializeField]
	private int animationState;
	public int getAnimationState()
	{
		return animationState;
	}

	[SerializeField]
	private bool MainEvent = false;
	public bool isMainEvent()
	{
		return MainEvent;
	}

	protected bool finished = true;
	public bool isFinished()
	{
		return finished;
	}

	protected bool gotTriggered;
	public bool GotTriggered()
	{
		return gotTriggered;
	}

	public virtual void Triggered()
	{
		gotTriggered = true;
	}
}