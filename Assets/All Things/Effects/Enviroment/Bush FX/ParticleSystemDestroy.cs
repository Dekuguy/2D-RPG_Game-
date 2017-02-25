using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDestroy : MonoBehaviour {

    private float time = 0;

	// Update is called once per frame
	void Update () {
        Debug.Log(GetComponent<ParticleSystem>().main.startLifetime.constant);
        time += Time.deltaTime;
        if(time >= GetComponent<ParticleSystem>().main.startLifetime.constant)
        {
            Destroy(this.gameObject);
        }
	}
}
