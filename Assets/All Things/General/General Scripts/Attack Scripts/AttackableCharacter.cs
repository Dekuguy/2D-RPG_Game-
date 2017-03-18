using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableCharacter : AttackableBase {

    [SerializeField]
    private int lives = 3;

	public int Lives { get { return lives; } }

    public override void OnHit(ItemType item)
    {
        lives--;
        if(lives <= 0)
        {
            WorldFunktions.FreezeLivingMovement(true);
			GetComponentInChildren<SpriteRenderer>().enabled = false;
			Destroy();
        }
    }

	public void AddHearts(int amount)
	{
		if(lives + amount <= DataBase.AllVariables.character_MaxLives)
		{
			lives += amount;
		}else
		{
			lives = DataBase.AllVariables.character_MaxLives;
		}
	}
	public void SetHearts(int amount)
	{
		lives = amount;
	}
}
