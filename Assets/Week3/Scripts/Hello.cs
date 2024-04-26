using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        Debug.Log(transform.localPosition);
        //transform.localPosition = new Vector3(1.0f, 2.0f, 3.0f);
        transform.rotation = Quaternion.Euler(0.0f, 45.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Hi");
        //transform.Translate(0.01f, 0.0f, 0.0f);
        transform.Rotate(0.0f, 0.1f, 0.0f);
    }
}
