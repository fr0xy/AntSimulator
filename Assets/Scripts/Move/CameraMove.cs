using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.SetParent(Player.transform);
        transform.localPosition = new Vector3(-3f, 1.5f, 0);
        transform.eulerAngles = new Vector3(25, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
