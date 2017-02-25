using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentFakePerstectiveLayer : MonoBehaviour
{

    [SerializeField]
    private float bottomOffset = 2;
    [Header("Debug")]
    [SerializeField]
    private bool ShowGizmos = false;

    private GameObject Player;

    private Vector3 bottom;
    private Vector3 distance;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        if (Player == null)
        {
            Debug.LogError("No Player in the Scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        bottom = transform.position - new Vector3(0, GetComponentInChildren<SpriteRenderer>().sprite.bounds.extents.y);
        distance = Player.transform.position - bottom;
        if (distance.y > bottomOffset)
        {
            GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Foreground";
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().sortingLayerName = "Background";
        }
    }

    //Debug
    void OnDrawGizmos()
    {
        if (ShowGizmos)
        {
            bottom = transform.position - new Vector3(0, GetComponentInChildren<SpriteRenderer>().sprite.bounds.extents.y);
            Gizmos.DrawLine(bottom, bottom + new Vector3(0, bottomOffset));
        }
    }
}
