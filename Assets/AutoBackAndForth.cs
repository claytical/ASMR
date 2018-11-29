using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBackAndForth : MonoBehaviour {
    private bool attached = false;
    private GameObject attachedObject;
    public bool moveBackAndForth;
    public float distanceToMove;
    private float minX;
    private float maxX;

    // Use this for initialization
    void Start () {
        minX = transform.position.x;
        maxX = transform.position.x + distanceToMove;
    }

    // Update is called once per frame
    void Update () {
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, maxX - minX) + minX, transform.position.y, transform.position.z);
    }

    public void Reset()
    {
        minX = transform.position.x;
        maxX = transform.position.x + distanceToMove;

    }
}
