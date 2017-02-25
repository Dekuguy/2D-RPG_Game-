using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem_Ruby : PickUpItem {

	[SerializeField]
	private int RubyAmount;

	[SerializeField]
	private AnimationCurve pickedUpAnimation;
	[SerializeField]
	private float animationmultiplyer = 1;

	private float time = -1f;

	private GameObject child;
	private Vector2 position;

	void OnTriggerEnter2D(Collider2D col)
	{

		if (col.tag == "Player")
		{
			Character.m_InventoryModel.AddItem(ItemType.Ruby, RubyAmount);

			GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);

			child = transform.GetChild(0).gameObject;
			position = child.transform.localPosition;

			time = 0;
		}
	}

	void Update()
	{
		if(time >= 0)
		{
			time += Time.deltaTime * animationmultiplyer;
			child.transform.localPosition = position + new Vector2(0, pickedUpAnimation.Evaluate(time));
		}
		if(time >= 1.1f)
		{
			Destroy(this.gameObject);
		}
	}
}
