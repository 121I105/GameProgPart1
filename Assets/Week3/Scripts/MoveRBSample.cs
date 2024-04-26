using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRBSample : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //m_Rigidbody.AddForce(0.0f, 0.0f, 500.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        m_Rigidbody.AddForce(horiz * 10.0f, 0.0f, vert * 10.0f);
    }
}
