using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoVRNavigation : MonoBehaviour {
    public float speed;
    private Rigidbody body;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
    }
	
	// Update is called once per frame
	void Update () {
        checkInput();	
	}

    void checkInput()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.MovePosition(transform.position + (Vector3.forward * speed));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            body.MovePosition(transform.position + (Vector3.back * speed));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.MovePosition(transform.position + (Vector3.right * speed));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.MovePosition(transform.position + (Vector3.left * speed));
        }

    }
}
