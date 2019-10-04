using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour {

    public float distanceToTravel;
    public float radius;

    public GameObject cylinder;
    public GameObject player;
    private float audioVisualScale = .1f;
    private bool movementEnabled = false;
    private bool didChangeMovementState = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 axis;
    private Vector3 desiredPosition;
    private float radiusSpeed;
    private float rotationSpeed;
    private LineRenderer line;
    public float updateStep = 0.1f;
    private int sampleDataLength = 256;

    private float currentUpdateTime = 0f;
    private float currentScale;

    private float clipLoudness;
    private float[] clipSampleData;
    private AudioSource audioSource;

    [System.Serializable]
    public enum AutoMovementType
    {
        BackAndForth,
        OrbitRight,
        OrbitLeft,
        Stationary,
        OrbitAroundPlayer
    }
    public AutoMovementType movementType;

    // Use this for initialization
    void Start() {
        radiusSpeed = .5f;
        rotationSpeed = 80f;
        if (GetComponent<AudioSource>())
        {
            audioSource = GetComponent<AudioSource>();
            clipSampleData = new float[sampleDataLength];
        }
        currentScale = cylinder.transform.localScale.z;
    }
        // Update is called once per frame
        void Update() {
            currentUpdateTime += Time.deltaTime;
            if (currentUpdateTime >= updateStep && audioSource != null)
            {
                currentUpdateTime = 0f;
                bool gotData = audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); //I read 1024 samples, which is about 80 ms on a 44khz stereo clip, beginning at the current sample position of the clip.
                clipLoudness = 0f;
                for (int i = 0; i < clipSampleData.Length; i++)
                {
                    clipLoudness += Mathf.Abs(clipSampleData[i]);
                }
                clipLoudness /= sampleDataLength; //clipLoudness is what you are looking for
            Vector3 newScale = cylinder.transform.localScale;
            newScale.x = currentScale + (clipLoudness * audioVisualScale);
            newScale.z = currentScale + (clipLoudness * audioVisualScale);
            cylinder.transform.parent = null;
            cylinder.transform.localScale = newScale;
            cylinder.transform.parent = transform;
        }

        if (movementEnabled)
        {
            switch (movementType)
            {
                case AutoMovementType.OrbitRight:
                  
                    transform.RotateAround(startPosition, axis, rotationSpeed * Time.deltaTime);
                    desiredPosition = (transform.position - startPosition).normalized * radius + startPosition;
                    transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
                    break;
                case AutoMovementType.OrbitLeft:
                    transform.RotateAround(startPosition, axis, -rotationSpeed * Time.deltaTime);
                    desiredPosition = (transform.position - startPosition).normalized * radius + startPosition;
                    transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
                    break;

                case AutoMovementType.BackAndForth:
                    Debug.Log("Moving along x axis: " + transform.position);
                    //                    transform.position = new Vector3(Mathf.PingPong(Time.time, endPosition.x - startPosition.x) + startPosition.x, transform.position.y, transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime);
                    if(transform.position == endPosition)
                    {
                        endPosition = startPosition;
                        startPosition = transform.position;
                    }
                    break;
                case AutoMovementType.OrbitAroundPlayer:
                    Debug.Log("Orbiting Around Player");
                    transform.RotateAround(player.transform.position, axis, rotationSpeed * Time.deltaTime);
                    desiredPosition = (transform.position - player.transform.position).normalized * radius + player.transform.position;
                    transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

                    break;
            }
        }
    }

    public void SetMovement(AutoMovementType mt)
    {
        movementType = mt;
        startPosition.Set(0, 0, 0);
        endPosition.Set(0, 0, 0);
        switch (movementType)
        {
            case AutoMovementType.OrbitLeft:
            case AutoMovementType.OrbitRight:
                axis = new Vector3(transform.parent.rotation.x, transform.parent.rotation.y, transform.parent.rotation.z);
                startPosition = transform.position + (transform.parent.transform.forward * .5f);
                transform.position = (transform.position - startPosition).normalized * radius + startPosition;
                break;
            case AutoMovementType.BackAndForth:
                Debug.Log("Setting X Axis Movement");
                //              startPosition.x = transform.position.x;
                //              endPosition.x = transform.position.x + distanceToTravel;
                startPosition = transform.position;
                endPosition = transform.position + (transform.parent.transform.forward * distanceToTravel);
                break;
            case AutoMovementType.Stationary:
                movementEnabled = false;
                break;
        }
        movementEnabled = true;

    }

    public void CheckMovement()
    {
        if(movementEnabled)
        {
            movementEnabled = false;
            didChangeMovementState = true;
        }

    }

    public void EndHover()
    {
        if(didChangeMovementState)
        {
            movementEnabled = true;
        }
    }
}
