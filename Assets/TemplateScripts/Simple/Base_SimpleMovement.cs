using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_SimpleMovement : Base {

	private bool Animating;
	private bool Frozen;
	public void SetAnimating(bool anim)
	{
		Animating = anim;
	}
	public bool isAnimating()
	{
		return Animating;
	}

	public void SetFrozen(bool frozen)
	{
		Frozen = frozen;
	}
	public bool isFrozen()
	{
		return Frozen;
	}
}
