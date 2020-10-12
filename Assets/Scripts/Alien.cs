using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //needed for NavMesh agent

public class Alien : MonoBehaviour
{
    //reference to the goal (target), value obtained through the inspector
    public Transform target;

    //times to track number of milliseconds to update the 
    //target location using NavMesh
    public float navigationUpdate;
    private float navigationTime = 0;

    //reference to the NPC (agent), value obtained in code below
    private NavMeshAgent agent; 

    // Start is called before the first frame update
    void Start()
    {
        //get the NavMesh agent on the oject with this script
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            //the NPC's goal is set to the players position
            //NavMesh agent does the rest! no need for vector
            //calculations as before

            //it updates the navigation path only after a certain amount of time not every frame
            //this is more efficient and saves on cpu resources 
            //time in measured in milliseconds
            navigationTime += Time.deltaTime;
            if (navigationTime > navigationUpdate)
            {
                //this line makes the NavMesh agent recalculate the path from 
                //agent to target...so do not want to do this every frame
                agent.destination = target.position;
                navigationTime = 0;
            }
        }
        
    }

    //when alien collides with a any object this trigger event goes off
    //and the alien is destroyed. We need to make sure in the collision
    //matrix of unity to make sure it only gets destroyed if it is hit
    //by a bullet, player, wall or head
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

