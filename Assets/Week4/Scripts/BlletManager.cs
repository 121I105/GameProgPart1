using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private GameObject m_BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = Instantiate(m_BulletPrefab, transform.position, transform.rotation);
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0.0f, 0.0f, 5.0f);
        }

        CheckBulletPosition();
    }

    void CheckBulletPosition()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");

        foreach (GameObject bullet in bullets)
        {
            if (bullet.transform.position.y <= 0.1f)
            {
                Destroy(bullet);
            }
        }
    }
}
