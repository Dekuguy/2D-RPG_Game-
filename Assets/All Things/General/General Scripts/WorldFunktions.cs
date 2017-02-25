using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFunktions
{

	public static void FreezeLivingMovement(bool freezing)
	{
		foreach (Base Livingthings in GameObject.FindObjectsOfType<Base>())
		{
			Livingthings.GetComponent<BaseMovementModel>().SetFrozen(freezing);
		}
	}

	public static void SetObjectSpriteLayer(GameObject obj, string Layername)
	{
		foreach(SpriteRenderer renderer in obj.GetComponentsInChildren<SpriteRenderer>())
		{
			renderer.sortingLayerName = Layername;
		}
		if(obj.GetComponent<SpriteRenderer>())
			obj.GetComponent<SpriteRenderer>().sortingLayerName = Layername;
	}

	public static void SetObjectSpriteLayerIndex(GameObject obj, int Layerindex)
	{
		foreach (SpriteRenderer renderer in obj.GetComponentsInChildren<SpriteRenderer>())
		{
			renderer.sortingOrder = Layerindex;
		}
		if (obj.GetComponent<SpriteRenderer>())
			obj.GetComponent<SpriteRenderer>().sortingLayerID = Layerindex;
	}
}
