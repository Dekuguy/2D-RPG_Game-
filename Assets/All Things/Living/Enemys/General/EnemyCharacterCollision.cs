using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterCollision : MonoBehaviour
{
    [SerializeField]
    private float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Vector2 direction = collision.transform.position - transform.position;
            direction.Normalize();
            GetComponent<EnemyKIMovement>().OnHitCharacter();



			if (collision.GetComponent<AttackableCharacter>())
			{
				collision.GetComponent<AttackableCharacter>().OnHit(ItemType.None);
			}

			if (collision.GetComponent<PushableObject>() != null)
			{
				if (!collision.gameObject.GetComponent<PushableObject>().isBeingPushedTimeOut())
					collision.gameObject.GetComponent<PushableObject>().PushCharacterRel(direction, 1);
			}
		}
    }
}
