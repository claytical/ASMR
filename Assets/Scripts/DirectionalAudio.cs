using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalAudio : MonoBehaviour {
    public GameObject player;
    public float raycastDistance;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);
        if (Physics.Raycast(transform.position, transform.forward * raycastDistance, out hit))
        {
           if(hit.transform.name == "Listener")
            {
                if(!GetComponent<AudioSource>().isPlaying)
                {
                    GetComponent<AudioSource>().Play();
                }
            }

        }


    }
}
