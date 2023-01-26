using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankObject : GavityObject
{
    private float speed = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.position -= transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -1f, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, 1f, 0);
        }
    }
}
