using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private float m_RotateSpeed;
    [SerializeField] private float m_GunPitchSpeed;
    [SerializeField] private GameObject m_BulletPrefub;
    GameObject m_GunBarrel;
    // Start is called before the first frame update
    void Start()
    {
        m_GunBarrel = GameObject.Find("GunBarrel");
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        transform.Rotate(0.0f, m_RotateSpeed * horiz * Time.deltaTime, 0.0f);
        m_GunBarrel.transform.Rotate(-m_GunPitchSpeed * vert * Time.deltaTime, 0.0f, 0.0f);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = Instantiate(m_BulletPrefub, m_GunBarrel.transform.position + m_GunBarrel.transform.forward * 0.5f, transform.rotation);
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = m_GunBarrel.transform.forward * 10.0f;
        }
    }
}
