using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnemyHitCollision : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Vector2 direction = collision.transform.position - transform.position;
            direction.Normalize();
            collision.GetComponent<EnemyKIMovement>().OnHitCharacter();

           
            if (!collision.gameObject.GetComponent<PushableObject>().isBeingPushedTimeOut())
                collision.gameObject.GetComponent<PushableObject>().PushCharacterRel(direction, 1);
            
        }
    }
}
