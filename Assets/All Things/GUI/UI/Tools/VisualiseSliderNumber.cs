using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class VisualiseSliderNumber : MonoBehaviour {

	public void SetNumber(float num)
	{
		if(num == 1)
		{
			Debug.Log("Test");
			GetComponent<Text>().text = "1";
			return;
		}
		if(num < 1)
			GetComponent<Text>().text = "0" + num.ToString("##.#", System.Globalization.CultureInfo.InvariantCulture);
		else
			GetComponent<Text>().text = num.ToString("##.#", System.Globalization.CultureInfo.InvariantCulture);
	}
}
