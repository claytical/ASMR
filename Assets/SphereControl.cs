using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour {

    public float distanceToTravel;
    public float radius;
    private bool movementEnabled = false;
    private bool didChangeMovementState = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 axis;
    private Vector3 desiredPosition;
    private float radiusSpeed;
    private float rotationSpeed;
    private LineRenderer line;
    [System.Serializable]
    public enum AutoMovementType
    {
        BackAndForth,
        OrbitRight,
        OrbitLeft,
        Stationary
    }
    public AutoMovementType movementType;

    // Use this for initialization
    void Start() {
        radiusSpeed = .5f;
        rotationSpeed = 80f;

    }

    // Update is called once per frame
    void Update() {

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
