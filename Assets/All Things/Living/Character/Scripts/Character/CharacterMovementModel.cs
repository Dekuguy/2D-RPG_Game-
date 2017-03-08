using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementModel : BaseMovementModel
{
	private bool m_isAttacking;
	private bool m_canAttack;
	private bool m_isPushing;

	private ItemType m_EquippedWeapon = ItemType.None;
	private ItemType m_EquippedShield = ItemType.None;

	private List<Vector2> disabledDirections;

	[HideInInspector]
	public bool isPushableObject;

	private void Awake()
	{
		m_Body = GetComponent<Rigidbody2D>();
		m_canMove = true;
		if (GetComponent<PushableObject>() != null)
		{
			isPushableObject = true;
		}
		else
		{
			isPushableObject = false;
		}
	}
	private void Start()
	{
		disabledDirections = new List<Vector2>();
	}


	void FixedUpdate()
	{
		UpdateMovement();
	}

	protected override void UpdateMovement()
	{
		Vector2 movement = Vector2.zero;

		if (!m_isFrozen || m_canMove)
		{

			if (isPushableObject)
			{
				if (GetComponent<PushableObject>().isBeingPushed())
				{
					movement = GetComponent<PushableObject>().getPushDirection();
				}
			}

			if (!isdisabledirection())
			{
				if (isPushableObject)
				{
					if (!GetComponent<PushableObject>().isBeingPushedTimeOut() && !isAttacking())
						movement = m_MovementDirection * DataBase.AllVariables.baseVariables.character_Speed;
				}
				else
				{
					if (!isAttacking())
						movement = m_MovementDirection * DataBase.AllVariables.baseVariables.character_Speed;
				}
			}
		}

		m_Body.velocity = movement;
	}

	public override Vector2 GetFacingDirection()
	{
		return m_FacingDirection;
	}
	public override Vector2 GetMovementDirection()
	{
		return m_MovementDirection;
	}
	public override bool isFrozen()
	{
		return m_isFrozen;
	}
	public override bool isMoving()
	{
		if (m_isFrozen)
		{
			return false;
		}
		return m_MovementDirection != Vector2.zero;
	}
	public override bool IsInAnimation()
	{
		return m_isInAnimation;
	}
	public bool isdisabledirection()
	{
		foreach (Vector2 d in disabledDirections)
		{
			if(d.x != 0) {
				if(d.x == m_FacingDirection.x)
				{
					Debug.Log("Test");
					return true;
				}
			}else if(d.y != 0)
			{
				if(d.y == m_FacingDirection.y)
				{
					return true;
				}
			}
		}
		return false;
	}
	public bool isPushing()
	{
		return m_isPushing;
	}

	public bool isAttacking()
	{
		return m_isAttacking;
	}
	public bool canAttack()
	{
		return m_canAttack;
	}
	public override bool canMove()
	{
		if (isPushableObject)
		{
			if (GetComponent<PushableObject>().isBeingPushedTimeOut())
				return false;
		}
		return m_canMove;
	}

	public void SetCanAttack(bool can)
	{
		if (m_isFrozen)
			m_canAttack = false;
		else if (m_EquippedWeapon == ItemType.None)
			m_canAttack = false;
		else if (m_isAttacking)
			m_canAttack = false;
		else
			m_canAttack = can;

	}
	public override void SetAnimation(bool animation)
	{
		m_isInAnimation = animation;
	}
	public override void SetFrozen(bool Frozen)
	{
		m_isFrozen = Frozen;
		m_canMove = !Frozen;
		if (m_isFrozen)
		{
			m_MovementDirection = Vector2.zero;
		}
	}
	public override void SetCanMove(bool Move)
	{
		m_canMove = Move;
	}
	public override void SetDirection(Vector2 direction)
	{
		if (!m_isFrozen)
		{
			m_MovementDirection = direction;
			if(direction != Vector2.zero)
			{
				m_FacingDirection = direction;
			}
		}else
		{
			m_MovementDirection = Vector2.zero;
		}
	}
	public void SetSimpleDirection(Vector2 direction)
	{
		if (!m_isFrozen)
		{
			Vector2 movingdirection = Vector2.zero;
			if (direction.x > 0)
				movingdirection.x = 1;
			if (direction.x < 0)
				movingdirection.x = -1;
			if (direction.y > 0)
				movingdirection.y = 1;
			if (direction.y < 0)
				movingdirection.y = -1;

			m_MovementDirection = movingdirection;

			if (movingdirection != Vector2.zero)
			{
				m_FacingDirection = movingdirection;
			}
		}
	}
	public override void SetFacingDirection(Vector2 direction)
	{
		Vector2 movingdirection = Vector2.zero;
		if (direction.x > 0)
			movingdirection.x = 1;
		if (direction.x < 0)
			movingdirection.x = -1;
		if (direction.y > 0)
			movingdirection.y = 1;
		if (direction.y < 0)
			movingdirection.y = -1;

		m_FacingDirection = movingdirection;
	}
	public void setisPushing(bool push)
	{
		if (!m_isFrozen)
		{
			if (!m_isAttacking)
			{
				if (!m_isInAnimation)
				{
					m_isPushing = true;
				}
			}
		}
		m_isPushing = false;
	}

	public void DisableSpecificDirectionMovement(Vector2 direction)
	{
		disabledDirections.Add(direction);
	}
	public void EnableSpecificDirectionMovement(Vector2 direction)
	{
		disabledDirections.Remove(direction);
	}
	public void EnableDirectionMovementComplete()
	{
		disabledDirections.Clear();
	}

	public void equipWeapon(ItemType item)
	{
		m_EquippedWeapon = item;
		ItemData itemData = DataBase.Item.FindItem(item);

		if (!Character.m_MovementView.WeaponParent.transform.FindChild(itemData.Prefab.name))
		{
			GameObject newEquippedObject = Instantiate(itemData.Prefab);
			newEquippedObject.name = itemData.Prefab.name;
			newEquippedObject.transform.parent = Character.m_MovementView.WeaponParent.transform;
			newEquippedObject.transform.localPosition = Vector3.zero;
		}

		Character.m_MovementView.SetEquippedWeapon(itemData);
	}
	public void equipShield(ItemType item)
	{
		m_EquippedShield = item;
		ItemData itemData = DataBase.Item.FindItem(item);

		if (!Character.m_MovementView.ShieldParent.transform.FindChild(itemData.Prefab.name))
		{
			GameObject newEquippedObject = Instantiate(itemData.Prefab);
			newEquippedObject.name = itemData.Prefab.name;
			newEquippedObject.transform.parent = Character.m_MovementView.ShieldParent.transform;
			newEquippedObject.transform.localPosition = Vector3.zero;
		}

		Character.m_MovementView.SetEquippedShield(itemData);
	}
	public void ShowPickuItem(ItemData Item)
	{
		WorldFunktions.FreezeLivingMovement(true);

		Character.m_MovementView.ShowPreview(Item);

		StartCoroutine(WaittoShowItem(Item.timetoShowAnimation));
	}
	IEnumerator WaittoShowItem(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		WorldFunktions.FreezeLivingMovement(false);
		Character.m_MovementView.HidePreview();
	}

	public void LiftUpObject()
	{
		m_canAttack = false;
		Character.m_MovementView.LiftUp();
	}
	public void ThrowLiftedObject()
	{
		m_canAttack = true;
		Character.m_MovementView.ThrowLiftedObject();
	}

	public void OnAttackStarted()
	{
		m_isAttacking = true;
		m_canMove = false;
		SetCanAttack(false);
	}
	public void OnAttackFinished()
	{
		m_isAttacking = false;
		m_canMove = true;
		SetCanAttack(true);
	}
}
