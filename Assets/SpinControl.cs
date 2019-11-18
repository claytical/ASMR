using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinControl : MonoBehaviour
{

    public GameObject objectToSpin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 //       objectToSpin.transform.RotateAround(transform.position, Time.deltaTime);
        objectToSpin.transform.Rotate(50 * Time.deltaTime, 0, 0, Space.World); //rotates 50 degrees per second around z axis
    }
}
