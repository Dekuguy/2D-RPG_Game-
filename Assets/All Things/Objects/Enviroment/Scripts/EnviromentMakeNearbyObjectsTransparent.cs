using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentMakeNearbyObjectsTransparent : MonoBehaviour {

    [SerializeField]
    private float alpha = 0.5f;
    [SerializeField]
    private float smooth = 2f;

    private GameObject Player;
    private SpriteRenderer sprite;

    private float alphavalue = 1f;
    private float targetalphavalue = 1f;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponentInChildren<SpriteRenderer>();
	}

    void Update() {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alphavalue);

        if(alphavalue != targetalphavalue)
            alphavalue = Mathf.Lerp(alphavalue, targetalphavalue, smooth * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            targetalphavalue = alpha;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Player") {
            targetalphavalue = 1f;
        }
    } 

}
