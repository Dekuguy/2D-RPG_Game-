using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRubys : MonoBehaviour
{
	[SerializeField]
	private Text Text;

	[Space]

	[SerializeField]
	private AnimationCurve scaleAnimation;
	[SerializeField]
	private float timemultiplyer = 1;

	private float time = -1f;

	private int currrent = -1;
	private int expected;

	void Update()
	{
		if (Text.text != Character.m_InventoryModel.getItemAmount(ItemType.Ruby).ToString() && currrent == -1)
		{
			currrent = int.Parse(Text.text);
			expected = Character.m_InventoryModel.getItemAmount(ItemType.Ruby);

			time = 0;
		}
		if(time >= 0)
		{
			Text.text = ((int)Mathf.Lerp(currrent, expected, time)).ToString();

			time += Time.deltaTime * timemultiplyer;
			Text.transform.localScale = Vector3.one * scaleAnimation.Evaluate(time);
			if (time >= 1)
			{
				Text.text = Character.m_InventoryModel.getItemAmount(ItemType.Ruby).ToString();

				currrent = -1;
				time = -1;
				Text.transform.localScale = Vector3.one;
			}
		}
	}
}