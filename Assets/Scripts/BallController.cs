using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float vel = 0.2f;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    public static bool _isGameOver = false;
    private bool _exitCollision = false;

    void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        rb.velocity = new Vector3(vel, 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isGameOver)
        {
            ChangeMovement();
        }

        if(!Physics.Raycast(transform.position, Vector3.down, 2) && _exitCollision)
        {
            Debug.Log("Game Over");
            _isGameOver = true;
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

    private void OnCollisionEnter(Collision collision)
    {
        rb.useGravity = false;
        _exitCollision = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.useGravity = true;
        _exitCollision = true;
    }
}
