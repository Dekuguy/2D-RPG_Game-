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
                _renderer.sprite = _facingSprites.front;
                _renderer.flipX = false;
                _renderer.sortingOrder = 150;
                break;
            case FacingDirection.back:
                _renderer.sprite = _facingSprites.back;
                _renderer.flipX = false;
                _renderer.sortingOrder = 50;
                break;
            case FacingDirection.left:
                _renderer.sprite = _facingSprites.side;
                _renderer.flipX = true;
                _renderer.sortingOrder = 150;
                break;
            case FacingDirection.right:
                _renderer.sprite = _facingSprites.side;
                _renderer.flipX = false;
                _renderer.sortingOrder = 150;
                break;
			case FacingDirection.left_front:
				_renderer.sprite = _facingSprites.halfside_front;
				_renderer.flipX = true;
				_renderer.sortingOrder = 150;
				break;
			case FacingDirection.right_front:
				_renderer.sprite = _facingSprites.halfside_front;
				_renderer.flipX = false;
				_renderer.sortingOrder = 150;
				break;
			case FacingDirection.back_left:
				_renderer.sprite = _facingSprites.halfside_back;
				_renderer.flipX = false;
				_renderer.sortingOrder = 50;
				break;
			case FacingDirection.back_right:
				_renderer.sprite = _facingSprites.halfside_back;
				_renderer.flipX = true;
				_renderer.sortingOrder = 50;
				break;

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