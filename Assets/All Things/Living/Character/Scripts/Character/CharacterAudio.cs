using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : BaseAudio {

	[SerializeField]
	private SoundData Attack;

	private bool AudioIsPlaying;

	// Use this for initialization
	void Start () {
		m_audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!AudioIsPlaying)
		{
			UpdateAttack();
		}else
		{
			if (!m_audio.isPlaying && !Character.m_MovementModel.isAttacking())
			{
				AudioIsPlaying = false;
			}
		}
	}

	private void UpdateAttack()
	{
		if (Character.m_MovementModel.isAttacking())
		{
			AudioIsPlaying = true;
			m_audio.PlayOneShot(Attack.Audio, Attack.volume);
		}
	}
}
