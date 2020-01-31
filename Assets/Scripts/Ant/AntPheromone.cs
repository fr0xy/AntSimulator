using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntPheromone : MonoBehaviour
{
    public GameObject PheromoneNeutralPrefab;
    public GameObject PheromoneFoodFindedPrefab;
    public GameObject PheromoneHungerPrefab;
    public GameObject Pheromone;
    public GameObject PheromoneToFollow = null;
    private Collider[] Cols;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cols = Physics.OverlapSphere(transform.position, 5, LayerMask.GetMask("Pheromone"));
        PheromoneToFollow = findOldestPheromone(Cols);
    }
    public void PopNeutralPheromone() {
        Pheromone = Instantiate(PheromoneNeutralPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        Pheromone.GetComponent<Pheromone>().timeLeft = Pheromone.GetComponent<ParticleSystem>().main.duration;
    }
    public void PopFoodFindedPheromone() {
        Pheromone = Instantiate(PheromoneFoodFindedPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        Pheromone.GetComponent<Pheromone>().timeLeft = Pheromone.GetComponent<ParticleSystem>().main.duration;
    }
    public void PopHungerPheromone() {
        Pheromone = Instantiate(PheromoneFoodFindedPrefab, transform.position, new Quaternion(0, 0, 0, 0));
        Pheromone.GetComponent<Pheromone>().timeLeft = Pheromone.GetComponent<ParticleSystem>().main.duration;
    }
    GameObject findOldestPheromone(Collider[] cols) {
        GameObject OldestPheromone = null;
        bool isHungry = false;
        foreach (Collider Col in cols)
        {
            if (Col.gameObject.GetComponent<Pheromone>().isHungry == true) {
                isHungry = true;
                if (OldestPheromone == null || OldestPheromone.GetComponent<Pheromone>().isFood == true)
                    OldestPheromone = Col.gameObject;
                else if (Col.gameObject.GetComponent<Pheromone>().timeLeft > OldestPheromone.GetComponent<Pheromone>().timeLeft) {
                    OldestPheromone = Col.gameObject;
                }
            }
            if (Col.gameObject.GetComponent<Pheromone>().isFood == true && isHungry == false) {
                if (OldestPheromone == null)
                    OldestPheromone = Col.gameObject;
                else if (Col.gameObject.GetComponent<Pheromone>().timeLeft < OldestPheromone.GetComponent<Pheromone>().timeLeft) {
                    OldestPheromone = Col.gameObject;
                }
            }
        }
        return OldestPheromone;
    }
}
