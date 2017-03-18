using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisableObjects : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> DisableGameobject;
	[SerializeField]
	private List<GameObject> EnableGameobject;


	public void EnableOBJ(bool yes)
	{
		Debug.Log(DisableGameobject[0].name);

		if (DisableGameobject.Count >= 1)
		{
			foreach (GameObject i in DisableGameobject)
			{
				i.SetActive(!yes);
			}
		}
		if (EnableGameobject.Count >= 1)
		{
			foreach (GameObject i in EnableGameobject)
			{
				i.SetActive(yes);
			}
		}
	}

}
