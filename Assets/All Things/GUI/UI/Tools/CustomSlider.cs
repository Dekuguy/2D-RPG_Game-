using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomSlider : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> DisableGameobject;


	public void IsSettingValue(bool yes)
	{
		Debug.Log(DisableGameobject[0].name);
		foreach (GameObject i in DisableGameobject)
		{
			i.SetActive(!yes);
		}
	}

}
