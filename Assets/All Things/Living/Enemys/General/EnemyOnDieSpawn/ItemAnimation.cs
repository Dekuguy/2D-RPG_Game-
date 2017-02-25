using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimation : MonoBehaviour {

	[SerializeField]
	private AnimationCurve dropcurve;
	[SerializeField]
	private float timemultiplyer = 1;
	[SerializeField]
	private float speed = 1;

	private float time;

	private Vector3 direction;
	private Vector3 orgposition;

	void Start()
	{
		direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
		orgposition = transform.position;
	}

	void Update()
	{
		time += Time.deltaTime;
		if(time >= 1)
		{
			Destroy(this);
		}else
		{
			transform.position = orgposition + direction * time * speed + Vector3.up * dropcurve.Evaluate(time);
		}
	}
}
