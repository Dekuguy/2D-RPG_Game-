using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementModel : BaseMovementModel
{
    private bool m_isAttacking;
	private bool m_canAttack;

    private ItemType m_EquippedWeapon = ItemType.None;
    private ItemType m_EquippedShield = ItemType.None;

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


    void FixedUpdate()
    {
        UpdateMovement();
    }

    protected override void UpdateMovement()
    {
        if (!m_isFrozen || m_canMove)
        {
            if (m_MovementDirection != Vector2.zero)
            {
                m_MovementDirection.Normalize();
            }

            if (isPushableObject)
            {
                if (GetComponent<PushableObject>().isBeingPushed())
                {
                    m_Body.velocity = GetComponent<PushableObject>().getPushDirection();
                }
            }

            if (isPushableObject)
            {
                if (!GetComponent<PushableObject>().isBeingPushedTimeOut() && !isAttacking())
                    m_Body.velocity = m_MovementDirection * DataBase.AllVariables.baseVariables.character_Speed;
                else
                    m_Body.velocity = Vector2.zero;
            }
            else
            {
                if (!isAttacking())
                    m_Body.velocity = m_MovementDirection * DataBase.AllVariables.baseVariables.character_Speed;
                else
                    m_Body.velocity = Vector2.zero;
            }
        }

        else
        {
            m_Body.velocity = Vector2.zero;
        }
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
            if (direction != Vector2.zero)
            {
                m_FacingDirection = direction;
            }
        }
        else
        {
            m_MovementDirection = Vector2.zero;
        }
    }
	public override void SetFacingDirection(Vector2 direction)
	{
		m_FacingDirection = direction;
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
