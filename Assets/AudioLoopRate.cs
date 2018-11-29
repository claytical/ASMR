using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoopRate : MonoBehaviour {
    private AudioSource sound;
    public float loopRate;
    private float timeSinceLastLoop;
	// Use this for initialization
	void Start () {
        sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!sound.isPlaying)
        {
            timeSinceLastLoop += Time.deltaTime;
            if(timeSinceLastLoop >= loopRate)
            {
                sound.Play();
                timeSinceLastLoop = 0f;
            }
        }
	}
}
