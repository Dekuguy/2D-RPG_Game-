using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovementView : BaseMovementView
{
    Bat scripts;

    void Awake()
    {
        scripts = GetComponent<Bat>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
    }

    protected override void UpdateDirection()
    {
        if (!scripts.MovementModel.isFrozen())
        {
            _animator.speed = 1;
            _animator.SetBool("IsMoving", scripts.MovementModel.isMoving());
        }
        else
        {
            _animator.speed = 0;
        }
    }

    public void TakeHit()
    {
        _animator.SetTrigger("TakeHit");
    }
    public void Die()
    {
        _animator.SetTrigger("Die");
        GameObject effect = Instantiate(scripts.EnemyDieEffect);
        effect.transform.parent = this.transform;
        effect.transform.localPosition = Vector2.zero;
    }
}
