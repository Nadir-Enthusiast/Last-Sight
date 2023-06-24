using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public string hitTag;

    public int thiefReach = 36;
    public int capacity;
    public float distanceTo;

    public bool stolen = false;

    public GameObject theThief;
    
    public Transform target;
    public Transform exitPoint;

    public static int thiefState;

    NavMeshAgent nav;
    
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        hitTag = "None";
        RaycastHit Hit;
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Hit, thiefReach))
        {
            distanceTo = Hit.distance;
            hitTag = Hit.transform.tag;
            if(!stolen && hitTag == "Player")
            {
                nav.SetDestination(target.position);
            }
        }
        if(hitTag == "Player" && distanceTo < 4 && !stolen)
        {
            stolen = true;
            if(GlobalGold.goldValue >= capacity)
            {
                GlobalGold.goldValue -= capacity;
            }
            else
            {
                GlobalGold.goldValue = 0;
            }
        }
        if(stolen)
        {
            nav.SetDestination(exitPoint.position);
        }

        if (!nav.pathPending && stolen)
        {
            if (nav.remainingDistance <= nav.stoppingDistance)
            {
                if (!nav.hasPath || nav.velocity.sqrMagnitude == 0f)
                {
                    theThief.SetActive(false);
                }
            }
        }
    }
}
