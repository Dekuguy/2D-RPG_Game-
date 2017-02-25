using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionModel : MonoBehaviour
{

	private GameObject LiftedUpOBJ;


	public void OnInteract()
	{
		if (LiftedUpOBJ != null)
		{
			LiftedUpOBJ.GetComponent<InteractablePickUp>().Throw(Character.m_MovementModel.GetFacingDirection());
			Character.m_MovementModel.ThrowLiftedObject();
			LiftedUpOBJ = null;
			return;
		}

		InteractableBase usableInteractable = FindUsableInteractable();
		if (usableInteractable == null)
		{
			return;
		}
		//Debug.Log("Found Interactable! " + usableInteractable.name);
		usableInteractable.OnInteract();
	}

	public Collider2D[] getCloseColliders()
	{
		BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();

		return Physics2D.OverlapAreaAll((Vector2)transform.position + boxCollider.offset + boxCollider.size * 0.6f, (Vector2)transform.position + boxCollider.offset - boxCollider.size * 0.6f);
	}

	InteractableBase FindUsableInteractable()
	{
		Collider2D[] closecolliders = getCloseColliders();

		InteractableBase closestInteractable = null;
		float AngleToClosestInteractable = Mathf.Infinity;

		for (int i = 0; i < closecolliders.Length; i++)
		{
			InteractableBase colliderInteractable = closecolliders[i].GetComponent<InteractableBase>();

			if (colliderInteractable == null)
			{
				continue;
			}

			Vector3 directionToInteractable = closecolliders[i].transform.position - transform.position;
			float angleToInteractable = Vector3.Angle(directionToInteractable, Character.m_MovementModel.GetFacingDirection());
			if (angleToInteractable < 40)
			{
				if (angleToInteractable < AngleToClosestInteractable)
				{
					closestInteractable = colliderInteractable;
					AngleToClosestInteractable = angleToInteractable;
				}
			}

			//Debug.Log(i + ": " + closecolliders[i].name + " - Angle: " + angleToInteractable);
		}
		return closestInteractable;
	}

	public void LiftUpObject(GameObject obj)
	{
		if (!obj.GetComponent<InteractablePickUp>().TakeOrginial)
			LiftedUpOBJ = Instantiate(obj);
		else
			LiftedUpOBJ = obj;

		LiftedUpOBJ.transform.parent = Character.m_MovementView.LiftedUpObjectParent.transform;
		LiftedUpOBJ.transform.localPosition = Vector2.zero;

		Character.m_MovementModel.LiftUpObject();


		WorldFunktions.SetObjectSpriteLayer(LiftedUpOBJ, "AbovePlayer");

		Collider2D col = LiftedUpOBJ.GetComponent<Collider2D>();
		if (col)
		{
			col.enabled = false;
		}

		Debug.Log("", obj);
		obj.SendMessage("PickUp", SendMessageOptions.DontRequireReceiver);
	}

	MovableObject FindMovableObject()
	{
		Collider2D[] closecolliders = getCloseColliders();

		MovableObject closestMovable = null;
		float AngleToClosestInteractable = Mathf.Infinity;

		for (int i = 0; i < closecolliders.Length; i++)
		{
			MovableObject colliderMovable = closecolliders[i].GetComponent<MovableObject>();

			if (colliderMovable == null)
			{
				continue;
			}

			Vector3 directionToInteractable = closecolliders[i].transform.position - transform.position;
			float angleToInteractable = Vector3.Angle(directionToInteractable, Character.m_MovementModel.GetFacingDirection());
			if (angleToInteractable < 40)
			{
				if (angleToInteractable < AngleToClosestInteractable)
				{
					closestMovable = colliderMovable;
					AngleToClosestInteractable = angleToInteractable;
				}
			}

			//Debug.Log(i + ": " + closecolliders[i].name + " - Angle: " + angleToInteractable);
		}
		return closestMovable;
	}

	public void AttackMovableObject()
	{

	}
	public void DetatchMovableObject()
	{

	}
}

