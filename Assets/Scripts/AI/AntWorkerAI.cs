using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AntWorkerAI : MonoBehaviour
{
    AntMove Move;
    AntHunger Hunger;
    AntPheromone Pheromone;
    public GameObject foodTarget = null;
    // Start is called before the first frame update
    void Start()
    {
        Move = gameObject.GetComponent<AntMove>();
        Hunger = gameObject.GetComponent<AntHunger>();
        Pheromone = gameObject.GetComponent<AntPheromone>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pheromone.PheromoneToFollow && Pheromone.PheromoneToFollow.GetComponent<Pheromone>().isHungry == true) { // FOLLOW HUNGER PHEROMONE TO HUNGRY ANT
            Debug.Log("Nourir");
            Pheromone.PopNeutralPheromone();
            Hunger.wantToFeed = true;
            Move.Destination = Pheromone.PheromoneToFollow.transform.position;
        }
        else if (Hunger.reserveStomacValue >= 95 && Hunger.isFull == true) { //GO DELIVER FOOD
            Pheromone.PopFoodFindedPheromone();
            Move.Destination = Move.Anthill.transform.position;
        }
        else if (foodTarget && Vector3.Distance(foodTarget.transform.position, transform.position) > 3) { // GO CLOSE TO FOOD
            Pheromone.PopNeutralPheromone();
            Move.Destination = foodTarget.transform.position;
        }
        else if (foodTarget && Vector3.Distance(foodTarget.transform.position, transform.position) <= 3) { // EAT
            Hunger.Eat(foodTarget);
        }
        else if (Hunger.selfStomacValue <= 5 && Hunger.reserveStomacValue == 0) { // GO BACK TO ANTHILL TO EAT
            Pheromone.PopHungerPheromone();
            Move.Destination = Move.Anthill.transform.position;
        }
        else if (Pheromone.PheromoneToFollow && Pheromone.PheromoneToFollow.GetComponent<Pheromone>().isFood == true) { // FOLLOW FOOD PHEROMONE
            Debug.Log("Nouriture");
            Pheromone.PopNeutralPheromone();
            Move.Destination = Pheromone.PheromoneToFollow.transform.position;
        }
        else { // MOVE RANDOM
            Pheromone.PopNeutralPheromone();
            if (Move.isMoving == false)
                Move.Destination = RandomNavSphere(transform.position, 15, -1);
        }
    }
    void OnTriggerEnter(Collider Col) {
        if (Col.gameObject.tag == "Food")
            foodTarget = Col.gameObject;
    }
    public static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition (randomDirection, out navHit, distance, layermask);
        return navHit.position;
    }
}
