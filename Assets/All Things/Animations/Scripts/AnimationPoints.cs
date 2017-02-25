using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AnimationPoints : MonoBehaviour {

	public GameObject[] Points;

	private void Update()
	{
		Points = new GameObject[transform.childCount];
		for(int i = 0; i < transform.childCount; i++)
		{
			Points[i] = transform.GetChild(i).gameObject;
		}
	}
}
