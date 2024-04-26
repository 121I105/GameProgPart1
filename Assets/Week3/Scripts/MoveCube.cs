using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    float velocity;
    // Start is called before the first frame update
    void Start()
    {
        velocity = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime, 0.0f, 0.0f);
        //transform.Translate(0.1f * Time.deltaTime, 0.0f, 0.0f);
    }
}
