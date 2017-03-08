using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatKIMovenebt2 : EnemyKIMovement
{

    [SerializeField]
    private Vector2 Min_Max_Sightradius = new Vector2(3, 5);
    [SerializeField]
    private Vector2 Min_Max_RandomAttackTime;
    [SerializeField]
    private float TimeoutAfterAttack = 1f;
    [SerializeField]
    private float Attackslowspeed = 0.6f;

    //---------- Debug ------------
    [Header("Debug")]
    [SerializeField]
    private bool ShowGizmos;
    void OnDrawGizmos()
    {
        if (ShowGizmos)
        {
            Gizmos.DrawWireSphere(transform.position, Min_Max_Sightradius.x);
            Gizmos.DrawWireSphere(transform.position, Min_Max_Sightradius.y);
        }
    }
    //-----------------------------

    private GameObject Player;
    private float timetoAttck;
    private bool flyright = true;
    private bool isInRange = false;

    private float Playerdistance()
    {
        return ((Vector2) Player.transform.position - (Vector2) transform.position).magnitude;
    }
    private Vector2 FlyAroundPoint(Vector2 point, bool flyright, float distance, float speed)
    {
        Vector2 direction = point - (Vector2)transform.position;
        Vector2 optimalposition = (Vector2)Player.transform.position - direction.normalized * distance;

        if (ShowGizmos)
        {
            Debug.DrawLine(transform.position, Player.transform.position);
        }

        Vector2 Out;

        Out = new Vector2(direction.y, -direction.x);
        Out.Normalize();
        if (flyright)
            Out = -Out;

        Out = Out - Vector2.Lerp(Vector2.zero, ((Vector2)transform.position - optimalposition) * speed, 1 / speed);

        return Out;
    }
    private Vector2 Attack(float speed)
    {
        Vector2 direction = Player.transform.position - transform.position;

        Vector2 Out;

        Out = Vector2.Lerp(Vector2.zero, (direction.normalized * speed), (Vector2.ClampMagnitude(direction, 1.6f).magnitude * (direction.magnitude / speed + speed)) - 0.6f);

        return Out;
    }

    void Start()
    {
        Player = Character.character.gameObject;

        timetoAttck = Random.Range(Min_Max_RandomAttackTime.x, Min_Max_RandomAttackTime.y);
    }
    void Update()
    {

		if (!GetComponent<BaseMovementModel>().IsInAnimation())
		{

			if (Playerdistance() <= Min_Max_Sightradius.x)
			{
				isInRange = true;
			}
			if (Playerdistance() >= Min_Max_Sightradius.y)
			{
				isInRange = false;
			}

			if (isInRange)
			{
				timetoAttck -= Time.deltaTime;
				if (timetoAttck <= 0)
				{
					timetoAttck = Random.Range(Min_Max_RandomAttackTime.x, Min_Max_RandomAttackTime.y) + TimeoutAfterAttack;
					m_isAttacking = true;
					if (Random.Range(0, 2) == 0)
						flyright = true;
					else
						flyright = false;
				}

				if (m_isAttacking)
				{
					SetDirection(Attack(Attackslowspeed));
				}
				else
				{
					float distance = Min_Max_Sightradius.x * ((Mathf.Sin(Time.time * 4) / 3) + 1);
					float spd = 2 / ((Vector2)transform.position - (Vector2)Player.transform.position).magnitude;

					SetDirection(FlyAroundPoint(Player.transform.position, flyright, distance, spd));
				}
			}
			else
			{
				SetDirection(Vector2.zero);
				m_isAttacking = false;
			}
		}
    }
}
