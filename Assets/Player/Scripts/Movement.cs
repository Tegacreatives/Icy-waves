using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector2 movement;
    float speed;
    private AnimationHandler aninHandler;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 150f;
        aninHandler = GetComponent<AnimationHandler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce((transform.forward * movement.y * speed) + (transform.right * movement.x * speed));
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 35);
        aninHandler.SetAnimatorSpeed(rb.velocity.x + rb.velocity.z);
    }

    public void movementFunction(Vector2 input)
    {
        movement = input;
    }
}
