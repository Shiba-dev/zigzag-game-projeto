using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float vel = 0.2f;
    [SerializeField]
    private Rigidbody rb;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        rb.velocity = new Vector3(vel, 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeMovement();
        }

        if(!Physics.Raycast(transform.position, Vector3.down, 2))
        {
            Debug.Log("Game Over");
        }
    }

    void ChangeMovement()
    {
        if(rb.velocity.x != 0)
        {
            rb.velocity = new Vector3(0, 0, vel);
        }
        else
        {
            rb.velocity = new Vector3(vel, 0, 0);
        }
    }
}
