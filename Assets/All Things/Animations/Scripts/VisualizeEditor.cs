using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VisualizeEditor : MonoBehaviour {

	[SerializeField]
	private Color m_color = Color.white;
	[SerializeField]
	private float animationpathpointsradius = 0.2f;
	[SerializeField]
	private bool ShowGizmos = true;

	[SerializeField]
	private AnimationPoints _animPoints;

	void OnEnable()
	{
		_animPoints = GetComponent<AnimationPoints>();
	}

	void OnDrawGizmos()
	{
		Gizmos.color = m_color;

		if (ShowGizmos) {
			for (int i = 0; i < _animPoints.Points.Length; i++)
			{
				if (i >= 1)
				{
					Gizmos.DrawLine(_animPoints.Points[i - 1].transform.position, _animPoints.Points[i].transform.position);
				}
				Gizmos.DrawWireSphere(_animPoints.Points[i].transform.position, animationpathpointsradius);
			}
		}
	}
}
