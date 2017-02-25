using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationListener : MonoBehaviour {

    public void OnAttackStarted()
    {
        Character.m_MovementView.OnAttackStarted();
        Character.m_MovementModel.OnAttackStarted();
    }
    public void OnAttackFinished()
    {
        Character.m_MovementView.OnAttackFinished();
        Character.m_MovementModel.OnAttackFinished();
    }

    public void SetSortingOrderOfWeapon(int sortingOrder)
    {
        Character.m_MovementView.SetSortingOrderOfWeapon(sortingOrder);
    }
    public void SetWeaponDirection(ShieldView.FacingDirection direction)
    {
        Character.m_MovementView.SetWeaponDirection(direction);
    }
	public void SetLiftingUpObject(string Layername)
	{
		WorldFunktions.SetObjectSpriteLayer(Character.m_MovementView.LiftedUpObjectParent, Layername);
	}
}
