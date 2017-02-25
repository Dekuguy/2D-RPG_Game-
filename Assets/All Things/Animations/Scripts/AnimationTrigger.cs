﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{

	[SerializeField]
	public GameObject prefab;

	[Space]

	[SerializeField]
	private bool SimpleMovement = false;
	[SerializeField]
	private float Speed = 1;
	[SerializeField]
	private Vector3 Offset;

	[Space]

	[SerializeField]
	private int TriggerID = 0;
	[SerializeField]
	private float distance = 0.02f;

	private GameObject[] points;
	private int currentPoint;

	private bool isAnimating = false;
	private bool PointisTriggered = false;
	private bool isGoing = false;

	void Start()
	{
		points = GetComponent<AnimationPoints>().Points;

		//TriggerAnimation(TriggerID);
	}

	public void TriggerAnimation(int ID)
	{
		if (ID == TriggerID)
		{
			GeneralAnimationState.Animationstatus = 0;

			prefab.transform.position = points[0].transform.position + Offset;
			isAnimating = true;
			currentPoint = 0;

			if (!SimpleMovement)
				prefab.GetComponent<BaseMovementModel>().SetAnimation(true);
			else
			{
				if (prefab.GetComponent<Base_SimpleMovement>() != null)
					prefab.GetComponent<Base_SimpleMovement>().SetAnimating(true);
			}
		}
	}


	void Update()
	{ 
		if (isAnimating)
		{
			if (!PointisTriggered && !isGoing)
			{
				foreach (PointEvents_Base scripts in points[currentPoint].GetComponents<PointEvents_Base>())
				{
					scripts.Triggered();
				}

				PointisTriggered = true;
			}

			bool next = false;
			bool hasmain = false;
			foreach (PointEvents_Base scripts in points[currentPoint].GetComponents<PointEvents_Base>())
			{
				if (scripts.isMainEvent())
				{
					if (scripts.isFinished())
					{
						next = true;
					}
					hasmain = true;
				}
			}
			if (points[currentPoint].GetComponent<PointEvents_Base>().isFinished() && !hasmain)
			{
				next = true;
			}

			if (next && !isGoing)
			{
				if (currentPoint < points.Length - 1)
				{
					currentPoint++;
					PointisTriggered = false;
					isGoing = true;
				}
				else
				{
					isAnimating = false;

					GeneralAnimationState.Animationstatus = 0;

					if (!SimpleMovement)
						prefab.GetComponent<BaseMovementModel>().SetAnimation(false);
					else
					{
						if (prefab.GetComponent<Base_SimpleMovement>() != null)
							prefab.GetComponent<Base_SimpleMovement>().SetAnimating(false);
					}
				}
			}

			if (isGoing)
			{
				Vector2 direction = points[currentPoint].transform.position - prefab.transform.position;

				if (points[currentPoint].GetComponent<PointEvents_Base>().getAnimationState() <= GeneralAnimationState.Animationstatus)
				{
					Debug.Log(points[currentPoint].GetComponent<PointEvents_Base>().getAnimationState() + ", " + GeneralAnimationState.Animationstatus);
					if (SimpleMovement)
					{
						prefab.transform.position += ((Vector3)direction.normalized * Speed * DataBase.AllVariables.baseVariables.base_Speed + Offset) * Time.deltaTime;
					}
					else
					{
						prefab.GetComponent<BaseMovementModel>().SetDirection(direction);
					}
				}

				if (((Vector2)prefab.transform.position - (Vector2)points[currentPoint].transform.position).magnitude <= distance)
				{
					if (!SimpleMovement)
						prefab.GetComponent<BaseMovementModel>().SetDirection(Vector2.zero);

					if (points[currentPoint].GetComponent<PointEvents_Base>().getAnimationState() <= GeneralAnimationState.Animationstatus)
					{
						isGoing = false;
					}
				}
			}
		}
	}
}
