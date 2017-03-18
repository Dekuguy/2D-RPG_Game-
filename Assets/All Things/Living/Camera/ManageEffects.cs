using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ManageEffects : MonoBehaviour {

	private void Update()
	{
		GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = SaveAndLoadGame.m_saveOptions.BloomEffectIntensity;
	}
}
