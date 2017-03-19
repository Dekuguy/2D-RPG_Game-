using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionModel : MonoBehaviour
{
	[SerializeField]
	private Vector2 Interactionradius;
	[SerializeField]
	private Vector2 InteractionOffset;
	[SerializeField]
	private bool ShowGizmos;

	private GameObject LiftedUpOBJ;
	private GameObject MovableOBJ;


	public void OnInteract()
	{
		if(MovableOBJ != null)
		{
			DetatchMovableObject();
			return;
		}

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
		if (!usableInteractable.enabled)
		{
			return;
		}
		if (!usableInteractable.isActiveAndEnabled)
		{
			return;
		}

		//Debug.Log("Found Interactable! " + usableInteractable.name);
		usableInteractable.OnInteract();
	}

	public Collider2D[] getCloseColliders()
	{
		return Physics2D.OverlapAreaAll((Vector2)transform.position + InteractionOffset + Interactionradius * 0.5f, (Vector2)transform.position + InteractionOffset - Interactionradius * 0.5f);
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
		Character.m_CharacterAudio.LiftUpItem();

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

		obj.SendMessage("PickUp", SendMessageOptions.DontRequireReceiver);
	}

	public void AttatchMovableObject(GameObject obj)
	{
		Character.m_MovementModel.DisableSpecificDirectionMovement(new Vector2(Character.m_MovementModel.GetFacingDirection().y, -Character.m_MovementModel.GetFacingDirection().x));
		Character.m_MovementModel.DisableSpecificDirectionMovement(new Vector2(-Character.m_MovementModel.GetFacingDirection().y, Character.m_MovementModel.GetFacingDirection().x));

		Character.m_MovementModel.setisPushing(true);

		DataBase.AllVariables.character_Speed = 0.5f;

		MovableOBJ = obj;

		MovableOBJ.layer = LayerMask.NameToLayer("DontCollideWithPlayer");
	}
	public void DetatchMovableObject()
	{
		MovableOBJ.layer = LayerMask.NameToLayer("Default");

		MovableOBJ.SendMessage("DetachParent", SendMessageOptions.DontRequireReceiver);

		DataBase.AllVariables.character_Speed = 1;
		Character.m_MovementModel.setisPushing(false);
		Character.m_MovementModel.EnableDirectionMovementComplete();

		MovableOBJ = null;
	}

	private void OnDrawGizmos()
	{
		if (ShowGizmos)
		{
			Gizmos.DrawWireCube((Vector3)InteractionOffset + transform.position, (Vector3)Interactionradius);
		}
	}
}

