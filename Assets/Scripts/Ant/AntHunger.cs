using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntHunger : MonoBehaviour
{
    public float reserveStomacSize = 100;
    public float reserveStomacValue;
    public float selfStomacSize = 25;
    public float selfStomacValue;
    public float timeBetweenEat = 2;
    public float timeBetweenSelfEat = 20;
    public float timeSinceLastSelfEat;
    public float timeSinceLastEat;
    public bool wantToFeed = false;
    public bool isEating = false;
    public bool isFull = false;
    // Start is called before the first frame update
    void Start()
    {
        reserveStomacValue = reserveStomacSize / 4;
        selfStomacValue = selfStomacSize;
        timeSinceLastSelfEat = 20;
        timeSinceLastEat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEating == false) {
            timeSinceLastSelfEat -= Time.deltaTime;
            if (timeSinceLastSelfEat <= 0) {
                selfStomacValue--;
                timeSinceLastSelfEat = timeBetweenSelfEat;
                if (selfStomacValue <= 0) {
                    //Die();
                }
            }
        }
    }
    public void Eat(GameObject FoodTarget) {
        if (isEating == false && isFull == false) {
            isEating = true;
        }
        if (isEating == true) {
            timeSinceLastEat -= Time.deltaTime;
            if (timeSinceLastEat <= 0) {
                if (selfStomacValue < selfStomacSize) {
                    selfStomacValue += 100;
                    if (selfStomacValue > selfStomacSize)
                        selfStomacValue = selfStomacSize;
                } else if (reserveStomacValue < reserveStomacSize) {
                    reserveStomacValue += 100;
                    if (reserveStomacValue > reserveStomacSize)
                        reserveStomacValue = reserveStomacSize;
                } else {
                    isFull = true;
                    isEating = false;
                }
                timeSinceLastEat = timeBetweenEat;
            }
        }
    }
}