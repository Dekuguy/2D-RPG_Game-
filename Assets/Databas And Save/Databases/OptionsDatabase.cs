using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsDatabase : ScriptableObject {

	[SerializeField]
	private float bloomEffectIntensity;
	
	public float BloomEffectIntensity { get { return bloomEffectIntensity; } set { bloomEffectIntensity = value; } }
}
