using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlletManager : MonoBehaviour
{
    [SerializeField] private GameObject m_BulletPrefub;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = Instantiate(m_BulletPrefub, transform.position, transform.rotation);
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0.0f, 0.0f, 5.0f);
        }
    }
}
