using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityLibrary;

public class Player : MonoBehaviour
{
    public int speed;

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float throttle = Input.GetAxisRaw(InputAxisNames.Throttle);
        float verticalAxis = Input.GetAxisRaw(InputAxisNames.Vertical);

        if (verticalAxis > 0)
        {
            transform.Rotate(Vector3.forward);
        }
        else if (verticalAxis < 0)
        {
            transform.Rotate(Vector3.back);
        }

        float acceleration = throttle * speed;

        Vector3 throwaway = new Vector3();
        float angle;
        transform.rotation.ToAngleAxis(out angle, out throwaway);

        if (transform.rotation.z < 0)
            angle *= -1;

        float radianAngle = (float)(Math.PI / 180) * angle;

        Vector2 accelerationVector = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle));

        accelerationVector.x = (accelerationVector.x * acceleration) - (rb2d.velocity.x * 2);
        accelerationVector.y = (accelerationVector.y * acceleration) - (rb2d.velocity.y * 2);

        rb2d.AddForce(accelerationVector);
    }
}
