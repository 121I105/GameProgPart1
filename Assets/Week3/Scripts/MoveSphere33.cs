using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere33 : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector3(-1.0f, 0.0f, 0.0f);
        }

        else if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector3(1.0f, 0.0f, 0.0f);
        }

        else
        {
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
