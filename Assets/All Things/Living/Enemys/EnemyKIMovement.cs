using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKIMovement : BatBaseController
{
    protected bool m_isAttacking;

    public void OnHitCharacter()
    {
        m_isAttacking = false;
    }
}
