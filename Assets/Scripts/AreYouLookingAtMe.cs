using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreYouLookingAtMe : MonoBehaviour {


    // bool trigger by HMD raycast
    private bool isLooking = false;
    // Light from the second child (Spot light)
    private Light lt;
    // Sound from the first child (Pencil Sound)
    private AudioSource sound;

    public float duration = 1.0F;

    private float lightStart;
    private float lightEnd;
    private float volStart;
    private float volEnd;



    // Use this for initialization
    void Start () {
        lt = GetComponentInChildren<Light>();
        lightStart = 0f;
        lightEnd = 2.21f;
        sound = GetComponentInChildren<AudioSource>();
        volStart = 0;
        volEnd = 1.0f;

    }

    // Update is called once per frame
    void Update() {
        // Check if the user is looking at this object direction
        if (isLooking) {
            lt.intensity = Mathf.Clamp(lt.intensity + 0.5f * Time.deltaTime, lightStart, lightEnd);
            sound.volume = Mathf.Clamp(sound.volume + 0.5f * Time.deltaTime, volStart, volEnd);
        }
        else {
            lt.intensity = Mathf.Clamp(lt.intensity + -0.5f * Time.deltaTime, lightStart, lightEnd);
            sound.volume = Mathf.Clamp(sound.volume + -0.5f * Time.deltaTime, volStart, volEnd);
        }

        if (Input.GetKeyDown(KeyCode.L)) {
            isLooking = true;
        }
        else if (Input.GetKeyDown(KeyCode.O)) {
            isLooking = false;
        }



    }





}
