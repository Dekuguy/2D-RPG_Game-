using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovementModel : BaseMovementModel {

    private float time;

    void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
        m_canMove = true;
    }

    void Update()
    {
        UpdateMovement();
    }

    protected override void UpdateMovement()
    {
        if (m_isFrozen || !m_canMove)
        {
            m_Body.velocity = Vector2.zero;
            return;
        }

        m_Body.velocity = m_MovementDirection * DataBase.AllVariables.enemy_Speed;
    }

    public override Vector2 GetMovementDirection()
    {
        return m_MovementDirection;
    }
    public override Vector2 GetFacingDirection()
    {
        return m_FacingDirection;
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
    public override bool canMove()
    {
        return m_canMove;
    }
	public override bool IsInAnimation()
	{
		return m_isInAnimation;
	}

	public override void SetAnimation(bool animation)
	{
		m_isInAnimation = animation;
	}
	public override void SetFrozen(bool Frozen)
    {
        m_isFrozen = Frozen;
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

	public void OnHit(Vector2 originPosition, float force)
    {

    }
}
