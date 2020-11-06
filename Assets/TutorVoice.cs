using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorVoice : MonoBehaviour
{
    public Transform player;
    public AudioClip[] clips;
    public float timeDelayBeforeOrbit;
    private float startTime;
    private float endTime;
    public bool orbiting;


    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;



    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        endTime = startTime + timeDelayBeforeOrbit;
        Debug.Log("End Time: " + endTime);


    }

    // Update is called once per frame
    void Update()
    {



        if (!orbiting)
        {
            if (Time.time > endTime)
            {
                orbiting = true;
//                GetComponent<UnityStandardAssets.Utility.SmoothFollow>().enabled = false;
                transform.position = (transform.position - player.position).normalized * radius + player.position;

            }
        }
        else
        {
//            transform.Rotate(player.position, 10 * Time.deltaTime);

            transform.RotateAround(player.position, axis, rotationSpeed * Time.deltaTime);
            desiredPosition = (transform.position - player.position).normalized * radius + player.position;
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);


        }
    }
}
