using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatKIMovement : EnemyKIMovement
{

    [SerializeField]
    private float Sightradius = 3.5f;
    [SerializeField]
    private float InAttackRadius = 5f;
    [SerializeField]
    private Vector2 RandomFlyRange = new Vector2(1000, 5);
    [Header("(First Value = Max, Second Value is to check")]

    [SerializeField]
    private Vector2 RandomAttackRange = new Vector2(1000, 5);
    [Header("(First Value = Max, Second Value is to check")]

    [SerializeField]
    private float TimeAfterPlayerLost = 2f;
    private float timer = 0;

    [SerializeField]
    private float attackslow = 0.4f;

    [Header("Debug")]
    [SerializeField]
    private bool showDebug;


    private Vector2 m_MovementDirection;
    private bool PlayerIsInRadius;

    private bool toswitch = false;
    private Vector2 OrthogonalVector;
    private Vector2 RandomVector;

    // Update is called once per frame
    void Update()
    {
        m_MovementDirection = Vector2.zero;

        if ((getPlayerPosition() - (Vector2)transform.position).magnitude <= Sightradius || PlayerIsInRadius)
        {
            if ((getPlayerPosition() - (Vector2)transform.position).magnitude >= InAttackRadius)
            {
                PlayerIsInRadius = false;
                return;
            }

            timer = 0;
            PlayerIsInRadius = true;

            if (Random.Range(0, RandomAttackRange.x) < RandomAttackRange.y)
            {
                if (Character.m_MovementModel.isPushableObject)
                {
                    if (!Character.m_MovementModel.GetComponent<PushableObject>().isBeingPushedTimeOut())
                        m_isAttacking = true;
                }
                else
                    m_isAttacking = true;
            }

            if (m_isAttacking)
            {
                Attack();
            }
            else
            {
                FlyAroundPlayer(getPlayerPosition());
            }

        }
        else
        {
            PlayerIsInRadius = false;

            if (toswitch == true)
            {
                toswitch = false;
            }
            else
            {
                toswitch = true;
            }

            if (timer == 0)
            {
                RandomVector = (Vector2)transform.position + new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            }

            timer += Time.deltaTime;

            if (timer <= TimeAfterPlayerLost)
            {
                RandomVector += new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));

                toswitch = false;
                FlyAfterPlayerLost(RandomVector);
            }
        }

        SetDirection(m_MovementDirection);
    }

    void FlyAroundPlayer(Vector2 position)
    {
        Vector2 delta = position - (Vector2)transform.position;
        OrthogonalVector = new Vector2(-delta.y, delta.x);

        if (toswitch == true)
        {
            OrthogonalVector = -OrthogonalVector;
        }

        if (Random.Range(0, RandomFlyRange.x) < RandomFlyRange.y)
        {
            if (toswitch == true)
            {
                toswitch = false;
            }
            else
            {
                toswitch = true;
            }
        }

        m_MovementDirection = OrthogonalVector + delta * 0.5f * (delta.magnitude - 3);
        m_MovementDirection.Normalize();
    }
    void Attack()
    {
        Vector2 delta = getPlayerPosition() - (Vector2)transform.position;
        delta.Normalize();
        m_MovementDirection = delta * attackslow;
    }

    void FlyAfterPlayerLost(Vector2 vector)
    {
        FlyAroundPlayer(vector);
    }

    private Vector2 getPlayerPosition()
    {
        return Character.character.gameObject.transform.position;
    }
    void OnDrawGizmos()
    {
        if (showDebug)
        {
            Gizmos.DrawWireSphere(transform.position, InAttackRadius);
            Gizmos.DrawWireSphere(transform.position, Sightradius);
        }
    }
}
