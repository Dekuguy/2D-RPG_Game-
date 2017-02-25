using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_SimpleMovement : MonoBehaviour {

	private bool Animating;
	public void SetAnimating(bool anim)
	{
		Animating = anim;
	}
	public bool isAnimating()
	{
		return Animating;
	}
}
