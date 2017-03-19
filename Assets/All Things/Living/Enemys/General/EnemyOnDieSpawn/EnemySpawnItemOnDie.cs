 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnItemOnDie : MonoBehaviour {

	[SerializeField]
	private int amount = 1;
	[SerializeField]
	private bool randomize = false;

	[SerializeField]
	[Range(0,1)]
	private float randomspawn = 1;

	[Space]

	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private GameObject AnimationPrefab;
	[SerializeField]
	private SoundData DropSound;



	void GameObjectDestroyed()
	{
		Spawn();
		if(DropSound != null)
			GetComponent<AudioSource>().PlayOneShot(DropSound.Audio, DropSound.volume);
	}

	void Spawn()
	{
		if (Random.Range(0f, 1f) <= randomspawn)
		{
			int r_amount = amount;
			if (randomize)
				r_amount = Random.Range(1, 4);

			for (int i = 0; i < amount; i++)
			{
				GameObject anim = Instantiate(AnimationPrefab);
				anim.transform.position = this.transform.position;

				GameObject t = Instantiate(prefab);
				t.transform.position = this.transform.position;
				t.transform.parent = anim.transform;
			}
		}
	}
}
