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
		PlaySound(OverworldSound.Audio, OverworldSound.volume);
	}

	private void PlaySound(AudioClip clip, float volume)
	{
		_Audio.loop = true;
		_Audio.volume = volume;
		_Audio.clip = clip;
		_Audio.Play();
	}
}
