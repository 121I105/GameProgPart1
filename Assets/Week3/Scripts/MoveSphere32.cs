using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere32 : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        m_Rigidbody.AddForce(horiz * 1.0f, 0.0f, 0.0f);
    }
}
