using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class InteractableBase: MonoBehaviour {

    // Use this for initialization
    virtual public void OnInteract()
    {
        Debug.Log("OnInteract is Not Implemented!");
    }
}
