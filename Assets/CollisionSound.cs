using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {
    private bool playedAudio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(playedAudio)
        {
            if(!GetComponent<AudioSource>().isPlaying)
            {
                Destroy(gameObject);
            }
        }
	}
    void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
        playedAudio = true;
    }

    }
