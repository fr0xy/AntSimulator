using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AntMove : MonoBehaviour
{
    public Vector3 Destination;
    public GameObject Target;
    public GameObject Anthill;
    public bool isMoving = false;
    public bool isLooking = true;
    NavMeshAgent Agent;
    // Start is called before the first frame update
    void Start()
    {
        Destination = transform.position;
        Agent = gameObject.GetComponent<NavMeshAgent>();
        Anthill = GameObject.FindGameObjectWithTag("Anthill");
    }

    // Update is called once per frame
    void Update()
    {
        AnimMove();
        if (Target != null) {
            Destination = Target.transform.position;
            // if ()
        }
    }
    void AnimMove() {
        if (Vector3.Distance(Destination, transform.position) < 3) {
            isMoving = false;
        }
        else {
            isMoving = true;
            Agent.destination = Destination;
        }
    }
}
