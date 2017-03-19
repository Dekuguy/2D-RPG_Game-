using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBloom : MonoBehaviour
{
	public void SetBloomEffect(float amount)
	{
		SaveAndLoadGame.m_saveOptions.BloomEffectIntensity = amount;
	}
	public void OnEnable()
	{
		GetComponent<Slider>().value = SaveAndLoadGame.m_saveOptions.BloomEffectIntensity;
	}

}
