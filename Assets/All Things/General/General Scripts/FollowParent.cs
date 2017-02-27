using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowParent : MonoBehaviour {

	public GameObject follow;
	public bool Simple = false;
	public bool isOffset = true;

	private Vector2 offset = new Vector2(0, 0);
	private bool setOffset = false;

	private void Update()
	{
		if (follow)
		{
			if (isOffset && !setOffset)
			{
				offset = (transform.position - follow.transform.position);
				setOffset = true;
			}

			if (Simple)
			{
				transform.position = offset + (Vector2) transform.position;
			}
			else
			{
				if (GetComponent<Rigidbody2D>())
				{
					GetComponent<Rigidbody2D>().position = (Vector2) follow.transform.position + offset;
				}
			}
		}
		else
		{
			setOffset = false;
		}
	}
}
