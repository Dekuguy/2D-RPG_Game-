using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePickUp : InteractableBase
{
	[SerializeField]
	public bool TakeOrginial = false;

	[Space]

	[SerializeField]
	private AnimationCurve XCurve;
	[SerializeField]
	private AnimationCurve YCurve;
	[SerializeField]
	private float timemutiplyer = 1;
	[SerializeField]
	private float distance = 1;

	[Space]

	[SerializeField]
	private GameObject ParticleEffect;

	private float time = -1;
	private Vector3 startposition;
	private Vector2 direction;

	public override void OnInteract()
	{
		Character.m_InteractionModel.LiftUpObject(this.gameObject);
	}

	public void Throw(Vector2 direction)
	{
		transform.parent = null;
		Collider2D col = GetComponent<Collider2D>();
		if (col)
		{
			col.enabled = true;
		}
		col.isTrigger = true;
		this.gameObject.layer = LayerMask.NameToLayer("DontCollideWithPlayer");

		this.startposition = this.transform.position;
		this.direction = direction;
		time = 0;
	}

	void Update()
	{
		if (time >= 0)
		{
			time += Time.deltaTime * timemutiplyer;
			if (time >= 1)
			{
				time = -1;

				if (ParticleEffect)
				{
					GameObject t = Instantiate(ParticleEffect);
					t.transform.position = transform.position;
				}

				Destroy(this.gameObject);
			}
			else
			{
				transform.position = startposition + ((Vector3)direction * XCurve.Evaluate(time) + new Vector3(0, -YCurve.Evaluate(time))) * distance;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (time >= 0)
		{
			if (other.GetComponent<AttackableEnemy>())
			{
				other.GetComponent<AttackableEnemy>().OnHit(ItemType.Sword);
			}
			if (other.GetComponent<PushableObject>())
			{
				other.GetComponent<PushableObject>().PushCharacterRel((other.transform.position - transform.position), 1);
			}

			time = 2;
		}
	}
}
