using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEmitter : MonoBehaviour {
    public GameObject objectToEmit;
    public int spawnRate;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    if(Time.frameCount%spawnRate == 0)
        {
            Instantiate(objectToEmit, transform);
        }	
	}
}
