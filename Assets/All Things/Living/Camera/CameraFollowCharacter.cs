using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : Base_SimpleMovement
{

	[SerializeField]
	private GameObject follow;
	[SerializeField]
	private float smoothfactor;

	[Space]
	[SerializeField]
	private Vector3 Offset = new Vector3(0, 0, -10);

	void FixedUpdate()
	{
		if (!isAnimating())
		{
			this.transform.position = Vector3.Lerp(transform.position, follow.transform.position + Offset, smoothfactor * Time.deltaTime);
		}
	}
}
