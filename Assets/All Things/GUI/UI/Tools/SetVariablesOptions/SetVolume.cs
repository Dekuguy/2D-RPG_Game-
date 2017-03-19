using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour {

	public void F_SetVolume(float amount)
	{
		SaveAndLoadGame.m_saveOptions.Volume = amount;
	}
	public void OnEnable()
	{
		GetComponent<UnityEngine.UI.Slider>().value = SaveAndLoadGame.m_saveOptions.Volume;
	}
}
