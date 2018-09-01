using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeMotion : MonoBehaviour {
    private float xRotation = 0f;
    private float yRotation = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        xRotation += Input.GetAxis("Mouse X");
        yRotation -= Input.GetAxis("Mouse Y");
        transform.localEulerAngles = new Vector3(yRotation, xRotation, 0);
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody>().velocity = transform.forward;
        }
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

 	}
}
