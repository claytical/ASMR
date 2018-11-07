using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour {
    public Transform[] points;
    private int destinationPoint = 0;
    private UnityEngine.AI.NavMeshAgent agent;
    /*    public bool halfPipeMotion;
    private int currentPoint = 0;
    private int direction = 1;
    */
    // Use this for initialization
    void Start () {

        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destinationPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destinationPoint = (destinationPoint + 1) % points.Length;
    }
    // Update is called once per frame
    void Update() {
        if (!agent.pathPending && agent.remainingDistance < 0.5f) {
            GotoNextPoint();
        }
    }
}
