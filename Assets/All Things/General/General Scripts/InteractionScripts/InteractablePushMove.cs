using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowParent))]
public class InteractablePushMove : InteractableBase {

	private FollowParent t;
	private Vector2 disabledDirection;

	private void Awake()
	{
		t = GetComponent<FollowParent>();
	}

	public override void OnInteract()
	{
		Character.m_InteractionModel.AttatchMovableObject(this.gameObject);

		t.follow = Character.m_MovementView.MovableParent;
		GetComponent<Collider2D>().isTrigger = true;
	}

	void DetachParent()
	{
		Debug.Log("Test");
		t.follow = null;
		GetComponent<Collider2D>().isTrigger = false;
	}

	private void OnTriggerEnter2D()
	{
		if (t.follow)
		{
			disabledDirection = Character.m_MovementModel.GetFacingDirection();
			Debug.Log(disabledDirection);

			Character.m_MovementModel.DisableSpecificDirectionMovement(disabledDirection);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (t.follow)
		{
			Character.m_MovementModel.EnableSpecificDirectionMovement(disabledDirection);
		}
	}
}
