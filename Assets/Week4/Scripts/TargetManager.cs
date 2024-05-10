using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] GameObject m_ExplosionPrefab;  
    AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit!");
            m_AudioSource.Play();
            Destroy(collision.gameObject);
            GameObject vfx = Instantiate(m_ExplosionPrefab, collision.transform.position, Quaternion.identity);
            Destroy(vfx, vfx.GetComponent<ParticleSystem>().duration);
        }
    }
}
