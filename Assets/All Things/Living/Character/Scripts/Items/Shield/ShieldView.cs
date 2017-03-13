using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldView : MonoBehaviour {

    [SerializeField]
    private FacingSprites _facingSprites;

    private CharacterMovementModel m_MovementModel;
    private SpriteRenderer _renderer;

    void Awake()
    {
        m_MovementModel = Character.m_MovementModel;
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetFacingDirection(FacingDirection direction)
    {
        switch (direction)
        {
            case FacingDirection.front:
				SetFacingDirection(new Vector2(0, -1));
                break;
            case FacingDirection.back:
				SetFacingDirection(new Vector2(0, 1));
				break;
            case FacingDirection.left:
				SetFacingDirection(new Vector2(-1, 0));
				break;
            case FacingDirection.right:
				SetFacingDirection(new Vector2(1, 0));
				break;
			case FacingDirection.left_front:
				SetFacingDirection(new Vector2(-1, -1));
				break;
			case FacingDirection.right_front:
				SetFacingDirection(new Vector2(1, -1));
				break;
			case FacingDirection.back_left:
				SetFacingDirection(new Vector2(-1, 1));
				break;
			case FacingDirection.back_right:
				SetFacingDirection(new Vector2(1, 1));
				break;

		}
    }
	public void SetFacingDirection(Vector2 direction)
	{

		if (direction == new Vector2(0, -1))
		{
			_renderer.sprite = _facingSprites.front;
			_renderer.flipX = false;
			_renderer.sortingOrder = 150;
		}
		if (direction == new Vector2(0, 1))
		{
			_renderer.sprite = _facingSprites.back;
			_renderer.flipX = false;
			_renderer.sortingOrder = 50;
		}
		if (direction == new Vector2(-1, 0))
		{
			_renderer.sprite = _facingSprites.halfside_back;
			_renderer.flipX = true;
			_renderer.sortingOrder = 50;
		}
		if (direction == new Vector2(1, 0))
		{
			_renderer.sprite = _facingSprites.halfside_back;
			_renderer.flipX = false;
			_renderer.sortingOrder = 50;
		}
		if (direction == new Vector2(-1, -1))
		{
			_renderer.sprite = _facingSprites.halfside_back;
			_renderer.flipX = true;
			_renderer.sortingOrder = 50;
		}
		if (direction == new Vector2(1, -1))
		{
			_renderer.sprite = _facingSprites.halfside_back;
			_renderer.flipX = false;
			_renderer.sortingOrder = 50;
		}
		if (direction == new Vector2(-1, 1))
		{
			_renderer.sprite = _facingSprites.back;
			_renderer.flipX = false;
			_renderer.sortingOrder = 50;
		}
		if (direction == new Vector2(1, 1))
		{
			_renderer.sprite = _facingSprites.back;
			_renderer.flipX = true;
			_renderer.sortingOrder = 50;
		}

	}

	public enum FacingDirection
    {
        left,
        left_front,
        front,
        right_front,
        right,
        back_right,
        back,
        back_left,
    }
    [System.Serializable]
    private struct FacingSprites
    {
        
        public Sprite front;
        public Sprite halfside_front;
        public Sprite side;
        public Sprite halfside_back;
        public Sprite back;
    }
}