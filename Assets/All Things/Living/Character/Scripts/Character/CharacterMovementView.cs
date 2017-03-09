using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementView : BaseMovementView
{

	public GameObject WeaponParent;
	public GameObject PreviewParent;
	public GameObject ShieldParent;
	public GameObject LiftedUpObjectParent;
	public GameObject MovableParent;

	void Awake()
	{
		if (_animator == null)
			Debug.LogError("Character Animator is not setup!");
		if (WeaponParent == null)
			Debug.LogError("Weapon Parent is not setup!");

	}

	void Update()
	{
		UpdateDirection();
		UpdateHit();
		UpdateAttack();

		if (Character.m_MovementModel.isPushing())
		{
			
			_animator.SetBool("isPushing", true);
		}else
		{
			_animator.SetBool("isPushing", false);
		}
	}


	protected override void UpdateDirection()
	{
		if (Character.m_MovementModel.canMove())
		{
			Vector2 direction = Character.m_MovementModel.GetMovementDirection();
			Vector2 facingDirection = Character.m_MovementModel.GetFacingDirection();

			if (!Character.m_MovementModel.isdisabledirection())
			{
				if (facingDirection != Vector2.zero && !Character.m_MovementModel.isPushing())
				{
					_animator.SetFloat("DirectionX", facingDirection.x);
					_animator.SetFloat("DirectionY", facingDirection.y);

					SetWeaponDirection(facingDirection);
				}
				_animator.SetBool("IsMoving", Character.m_MovementModel.isMoving());
			}
			else
			{
				_animator.SetBool("IsMoving", false);
			}
		}
		else
		{
			_animator.SetBool("IsMoving", false);

			if (Character.m_MovementModel.isPushableObject)
			{
				if (GetComponent<PushableObject>().isBeingPushedTimeOut())
				{
					Vector2 direction = -GetComponent<PushableObject>().getPushDirection().normalized;

					_animator.SetFloat("DirectionX", direction.x);
					_animator.SetFloat("DirectionY", direction.y);
				}
			}
		}
	}
	void UpdateHit()
	{
		if (Character.m_MovementModel.isPushableObject)
		{
			_animator.SetBool("IsHit", GetComponent<PushableObject>().isBeingPushedTimeOut());
		}
	}
	void UpdateAttack()
	{
		if (Character.m_MovementModel.isPushableObject)
		{
			if (GetComponent<PushableObject>().isBeingPushedTimeOut())
			{
				OnAttackFinished();
			}
		}
	}

	public void LiftUp()
	{
		_animator.SetBool("isLifting", true);
		_animator.SetTrigger("OnLifting");
		ShowShield(false);
	}
	public void ThrowLiftedObject()
	{
		_animator.SetBool("isLifting", false);
		_animator.SetTrigger("ThrowsLiftedObject");

		ShowShield(true);
	}

	public void SetSortingOrderOfWeapon(int sortingOrder)
	{
		WorldFunktions.SetObjectSpriteLayerIndex(WeaponParent, sortingOrder);
	}
	public void SetWeaponDirection(ShieldView.FacingDirection direction)
	{
		ShieldView[] children = GetComponentsInChildren<ShieldView>();
		foreach (ShieldView t in children)
		{
			t.SetFacingDirection(direction);
		}
	}
	public void SetWeaponDirection(Vector2 direction)
	{
		ShieldView[] children = GetComponentsInChildren<ShieldView>();
		foreach (ShieldView t in children)
		{
			t.SetFacingDirection(direction);
		}
	}

	public void DoAttack()
	{
		_animator.SetTrigger("DoAttack");
	}
	public void OnAttackStarted()
	{
		ShowWeapon(true);
	}
	public void OnAttackFinished()
	{
		ShowWeapon(false);
	}

	private void ShowWeapon(bool show)
	{
		WeaponParent.SetActive(show);
	}
	private void ShowShield(bool show)
	{
		ShieldParent.SetActive(show);
	}

	public void ShowPreview(ItemData item)
	{
		if (!PreviewParent.transform.FindChild(item.Prefab.name))
		{
			GameObject newEquippedObject = Instantiate(item.Prefab);

			newEquippedObject.name = item.Prefab.name;
			newEquippedObject.transform.parent = PreviewParent.transform;
			newEquippedObject.transform.localPosition = Vector3.zero;

			Destroy(newEquippedObject.GetComponent<Collider2D>());
		}
		else
		{
			PreviewParent.transform.FindChild(item.Prefab.name).gameObject.SetActive(true);
		}

		ShowShield(false);
		PreviewParent.SetActive(true);
		if (item.pickUpAnimation == ItemData.PickUpAnimation.OneHand)
		{
			_animator.SetBool("PickUpOneHand", true);
		}
		else
		{
			_animator.SetBool("PickUpTwoHand", true);
		}
	}
	public void HidePreview()
	{
		_animator.SetBool("PickUpOneHand", false);
		_animator.SetBool("PickUpTwoHand", false);
		Destroy(PreviewParent.transform.GetChild(0).gameObject);

		ShowShield(true);
	}

	public void SetEquippedWeapon(ItemData equippedItem)
	{
		for (int i = 0; i < WeaponParent.transform.childCount; i++)
		{
			WeaponParent.transform.GetChild(i).gameObject.SetActive(false);
		}
		WeaponParent.transform.FindChild(equippedItem.Prefab.name).gameObject.SetActive(true);
	}
	public void SetEquippedShield(ItemData equippedItem)
	{
		for (int i = 0; i < ShieldParent.transform.childCount; i++)
		{
			ShieldParent.transform.GetChild(i).gameObject.SetActive(false);
		}
		ShieldParent.transform.FindChild(equippedItem.Prefab.name).gameObject.SetActive(true);
	}

}
