using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFunktions
{

	public static void FreezeLivingMovement(bool freezing)
	{
		foreach (Base Livingthings in GameObject.FindObjectsOfType<Base>())
		{
			if(Livingthings.GetComponent<BaseMovementModel>())
				Livingthings.GetComponent<BaseMovementModel>().SetFrozen(freezing);
			if (Livingthings.GetComponent<Base_SimpleMovement>())
				Livingthings.GetComponent<Base_SimpleMovement>().SetFrozen(freezing);

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
