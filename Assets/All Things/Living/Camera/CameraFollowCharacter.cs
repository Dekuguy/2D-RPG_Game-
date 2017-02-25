using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : Base_SimpleMovement {

	[SerializeField]
	private GameObject follow;

	void Update()
	{
		if(!isAnimating())
			this.transform.position = follow.transform.position + new Vector3(0, 0, -10);
	}
}
