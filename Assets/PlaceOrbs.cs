using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOrbs : MonoBehaviour {
    public List<GameObject> orbContainers;
    public List<GameObject> orbs;
    public float radius;

	// Use this for initialization
	void Start () {
  
        if(orbContainers.Count > 0)
        {
            foreach(GameObject container in orbContainers)
            {
                foreach (SphereControl orb in GetComponentsInChildren<SphereControl>()) { 
                    orbs.Add(orb.gameObject);
                }

            }
        }
        ResetPositions();

    }

    // Update is called once per frame
    void Update()
    {



        }

        public void ResetPositions()
    {

       


        Vector3 axis = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        Vector3 currentPosition = transform.position + (transform.transform.forward * radius);
        Vector3 currentY = new Vector3(0, .1f, 0);
        float angle = 0f;
        foreach (GameObject orb in orbs)
        {
            currentPosition.y = currentPosition.y + .01f;
            currentPosition.x = currentPosition.x + Mathf.Cos(angle) * (radius / 2);
            currentPosition.z = currentPosition.z + Mathf.Sin(angle) * (radius / 2);
            angle += .5f;
            orb.transform.position = currentPosition;
        }



        /*
                float spacing = .5f;
                float spacingY = .5f;
                float rotationSpeed = .8f;
                foreach (GameObject orb in orbs)
                {
                    orb.transform.RotateAround(transform.position, transform.up, 100 * Time.deltaTime);



                    orb.transform.position = currentPosition;
                    /*            currentPosition.y += spacingY;

                      */
        /*
currentPosition = (transform.position - currentPosition).normalized * radius + currentPosition;
currentPosition.y += spacingY;
currentPosition.x += spacing;
currentPosition.z += spacing;

transform.RotateAround(currentPosition, axis, rotationSpeed * Time.deltaTime);
Vector3 desiredPosition = (transform.position - currentPosition).normalized * radius + currentPosition;
orb.transform.SetPositionAndRotation(desiredPosition, transform.rotation);

//transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

}
*/
    }

}
