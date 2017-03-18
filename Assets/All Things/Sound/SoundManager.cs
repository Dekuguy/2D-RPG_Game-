using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	[SerializeField]
	private SoundData OverworldSound;

	private AudioSource _Audio;
	private void Awake()
	{
		_Audio = GetComponent<AudioSource>();
	}

	private void Start()
	{
		_Audio.loop = true;
		_Audio.volume = OverworldSound.volume;
		_Audio.clip = OverworldSound.Audio;
		_Audio.Play();
	}
}
