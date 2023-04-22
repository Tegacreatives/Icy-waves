using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private Rigidbody rb;
    private float speed;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void rotateCharacter(Vector2 input)
    {
        Vector3 tempVector = new Vector3(0, input.x * speed * Time.deltaTime, 0);
        Quaternion quaternion = Quaternion.Euler(tempVector);
        rb.MoveRotation(rb.rotation * quaternion);
    }

    public void setSpeed(float _speed) 
    {
        speed = _speed * speed;
    }
}
