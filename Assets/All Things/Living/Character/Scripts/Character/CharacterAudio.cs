using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAudio : BaseAudio
{
	[Header("General")]

	[SerializeField]
	private float generalvolume = 1;

	[Space]

	[SerializeField]
	private SoundData Hurt;

	[SerializeField]
	private SoundData LiftUp;
	[SerializeField]
	private SoundData Throw;

	[Header("Attack")]

	[SerializeField]
	private SoundData Attack1;
	[SerializeField]
	private SoundData Attack2;
	[SerializeField]
	private SoundData Attack3;

	private bool AudioIsPlaying;

	private int lastLives;
	// Use this for initialization
	void Start()
	{
		m_audio = GetComponent<AudioSource>();
		lastLives = Character.m_AttackableCharacter.Lives;
	}

	// Update is called once per frame
	void Update()
	{
		UpdateHurt();
		UpdateAttack();
	}

	private void UpdateAttack()
	{
		if (!AudioIsPlaying)
		{
			if (Character.m_MovementModel.isAttacking())
			{
				int rand = UnityEngine.Random.Range(0, 3);
				SoundData data = null;

				switch (rand)
				{
					case 0:
						data = Attack1;
						break;
					case 1:
						data = Attack2;
						break;
					case 2:
						data = Attack3;
						break;
				}

				AudioIsPlaying = true;

				m_audio.PlayOneShot(data.Audio, data.volume * generalvolume);
			}
		}
		else
		{
			if (!m_audio.isPlaying && !Character.m_MovementModel.isAttacking())
			{
				AudioIsPlaying = false;
			}
		}
	}
	private void UpdateHurt()
	{
		if (!m_audio.isPlaying)
		{
			if(lastLives != Character.m_AttackableCharacter.Lives)
			{
				lastLives = Character.m_AttackableCharacter.Lives;
				AudioIsPlaying = true;
				m_audio.PlayOneShot(Hurt.Audio, Hurt.volume);
			}
		}
	}

	public void LiftUpItem()
	{
		m_audio.PlayOneShot(LiftUp.Audio, LiftUp.volume);
	}
}
