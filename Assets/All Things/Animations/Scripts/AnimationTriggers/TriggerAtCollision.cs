using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAtCollision : TriggerBase {
	[Space]

	[SerializeField]
	private bool AllowJustPlayer = true;
	[SerializeField]
	private bool AllowAll = false;

	[Space]

	[SerializeField]
	private List<GameObject> validgameobjects;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (AllowJustPlayer)
		{
			if (collision.tag == "Player")
			{
				TriggerStart();
				return;
			}
		}
		else if (AllowAll)
		{
			TriggerStart();
			return;
		}
		else
		{
			foreach (GameObject t in validgameobjects)
			{
				if (t == collision.gameObject)
					TriggerStart();
			}
		}
	}
}
