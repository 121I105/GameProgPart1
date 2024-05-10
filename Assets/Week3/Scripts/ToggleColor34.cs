using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleColor34 : MonoBehaviour
{
    private MeshRenderer m_MeshRenderer;
    private Material m_Mat;
    // Start is called before the first frame update
    void Start()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        m_Mat = m_MeshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_Mat.color == Color.white)
        {
            m_Mat.color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && m_Mat.color == Color.red)
        {
            m_Mat.color = Color.white;
        }
    }
}
