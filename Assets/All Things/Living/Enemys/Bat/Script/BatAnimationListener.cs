using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAnimationListener : MonoBehaviour {

    public void EndDie()
    {
        Destroy(this.transform.parent.gameObject);
    }
}
