using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseControl : BaseControl {

    protected override void SetDirection(Vector2 direction)
    {
		if (!Character.m_MovementModel.IsInAnimation())
		{
			if (Character.m_MovementModel.isPushing())
			{
				Character.m_MovementModel.SetSimpleDirection(direction);
			}else
			{
				Character.m_MovementModel.SetDirection(direction);
			}
		}
    }

    protected void OnAttackPressed()
    {
        if (Character.m_MovementModel.canAttack() && !Character.m_MovementModel.IsInAnimation())
        {
            Character.m_MovementView.DoAttack();
        }
    }

    protected void OnInteractPressed()
    {
		if(!Character.m_MovementModel.IsInAnimation())
			Character.m_InteractionModel.OnInteract();
    }
}
