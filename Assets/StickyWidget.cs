using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyWidget : MonoBehaviour {
    public bool attached = false;
    public GameObject attachedObject;
    private bool xAxisEnabled = false;
    private bool zAxisEnabled = false;
    private bool orbitEnabled = false;
    public GameObject directionIndicator;
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
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//        directionIndicator.transform.LookAt(transform.forward);
        if(attached)
        {
        }		
	}


    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Colliding with " + col.gameObject.name);
        if (!attached)
        {
            Debug.Log("not attached yet...");
            if (col.gameObject.tag == "SoundSphere")
            {
                attached = true;
                Debug.Log("Attaching to " + col.gameObject.name);
                attachedObject = col.gameObject;
                attachedObject.transform.parent = gameObject.transform;
            }
        }
    }
    
    public void SetMovement()
    {
        switch (movementType)
        {
            case AutoMovementType.OrbitRight:
                if (attachedObject.GetComponent<SphereControl>())
                {
                    attachedObject.GetComponent<SphereControl>().SetMovement(SphereControl.AutoMovementType.OrbitRight);
                }
                break;
            case AutoMovementType.OrbitLeft:
                if (attachedObject.GetComponent<SphereControl>())
                {
                    attachedObject.GetComponent<SphereControl>().SetMovement(SphereControl.AutoMovementType.OrbitLeft);
                }
                break;
            case AutoMovementType.BackAndForth:
                if (attachedObject.GetComponent<SphereControl>())
                {
                    attachedObject.GetComponent<SphereControl>().SetMovement(SphereControl.AutoMovementType.BackAndForth);
                }
                break;
            case AutoMovementType.Stationary:
                if (attachedObject.GetComponent<SphereControl>())
                {
                    attachedObject.GetComponent<SphereControl>().SetMovement(SphereControl.AutoMovementType.Stationary);
                }
                break;
            case AutoMovementType.OrbitAroundPlayer:
                if (attachedObject.GetComponent<SphereControl>())
                {
                    attachedObject.GetComponent<SphereControl>().SetMovement(SphereControl.AutoMovementType.OrbitAroundPlayer);
                }
                break;
        }
    }


    public void Release()
    {
        if(attachedObject)
        {
            attachedObject.transform.parent = null;
            attached = false;
            attachedObject = null;
        }
    }

}
