using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableBush : AttackableBase {

    [SerializeField]
    private Sprite DestroyedSprite;
    [SerializeField]
    private GameObject DestroyEffect;

	[SerializeField]
	private SoundData DestroySound;

    public override void OnHit(ItemType item)
    {
		PickUp();
		if(DestroySound != null)
		{
			GetComponent<AudioSource>().PlayOneShot(DestroySound.Audio, DestroySound.volume);
		}
		if (DestroyEffect != null)
		{
			GameObject destroyEffect = (GameObject)Instantiate(DestroyEffect);
			destroyEffect.transform.position = this.transform.position;
		}

		Destroy();
    }

	public void PickUp()
	{
		GetComponentInChildren<SpriteRenderer>().sprite = DestroyedSprite;
		if (GetComponent<Collider2D>() != null)
		{
			GetComponent<Collider2D>().enabled = false;
		}
	}
}
