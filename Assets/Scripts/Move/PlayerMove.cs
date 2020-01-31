using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 12;
    public float rotationSpeed = 5;
    Rigidbody rigidBody;
    float moveX;
    float moveY;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
    void GetInput() {
        moveX = Input.GetAxis ("Horizontal");
        moveY = Input.GetAxis ("Vertical");
        Vector3 moveVector = transform.right * moveY * moveSpeed;//new Vector3(moveY * moveSpeed * transform.right.x, 0, moveY * moveSpeed * transform.right.x);
        transform.Rotate(0, moveX * rotationSpeed, 0);
        rigidBody.AddForce(moveVector);
    }
}
