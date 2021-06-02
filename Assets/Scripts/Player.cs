using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityLibrary;

public class Player : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float throttle = Input.GetAxisRaw(InputAxisNames.Throttle);

        GetComponent<Rigidbody2D>().velocity = new Vector2(speed * throttle, 0);

        float verticalAxis = Input.GetAxisRaw(InputAxisNames.Vertical);

        if (verticalAxis > 0)
        {
            transform.Rotate(Vector3.forward);
        }
        else if (verticalAxis < 0)
        {
            transform.Rotate(Vector3.back);
        }
    }
}
