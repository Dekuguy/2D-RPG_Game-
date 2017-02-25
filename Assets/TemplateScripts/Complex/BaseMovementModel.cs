using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovementModel : MonoBehaviour {

    protected Vector2 m_MovementDirection;
    protected Vector2 m_FacingDirection;

    protected Rigidbody2D m_Body;

    protected bool m_isFrozen;
    protected bool m_canMove;
	protected bool m_isInAnimation;

	protected abstract void UpdateMovement();

    public abstract Vector2 GetMovementDirection();
    public abstract Vector2 GetFacingDirection();
    public abstract bool isFrozen();
    public abstract bool isMoving();
    public abstract bool canMove();
	public abstract bool IsInAnimation();

	public abstract void SetAnimation(bool animation);
	public abstract void SetFrozen(bool Frozen);
    public abstract void SetCanMove(bool Move);
    public abstract void SetDirection(Vector2 direction);
	public abstract void SetFacingDirection(Vector2 direction);
}
