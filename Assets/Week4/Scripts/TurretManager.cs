using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [SerializeField] private float m_RotateSpeed;
    [SerializeField] private float m_GunPitchSpeed;
    [SerializeField] private GameObject m_BulletPrefab; // Corrected typo from "m_BulletPrefub" to "m_BulletPrefab"
    [SerializeField] private AudioClip m_MoveSound; // New move sound clip
    GameObject m_GunBarrel;
    AudioSource m_AudioSource;
    AudioSource m_MoveAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_GunBarrel = GameObject.Find("GunBarrel");
        m_AudioSource = GetComponent<AudioSource>();

        // Add a new AudioSource for the move sound
        m_MoveAudioSource = gameObject.AddComponent<AudioSource>();
        m_MoveAudioSource.clip = m_MoveSound;
        m_MoveAudioSource.loop = true; // Loop the move sound
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        bool isMoving = horiz != 0.0f || vert != 0.0f;

        // Rotate the turret base
        transform.Rotate(0.0f, m_RotateSpeed * horiz * Time.deltaTime, 0.0f);
        // Rotate the gun barrel
        m_GunBarrel.transform.Rotate(-m_GunPitchSpeed * vert * Time.deltaTime, 0.0f, 0.0f);

        // Play move sound when turret is moving
        if (isMoving && !m_MoveAudioSource.isPlaying)
        {
            m_MoveAudioSource.Play();
        }
        else if (!isMoving && m_MoveAudioSource.isPlaying)
        {
            m_MoveAudioSource.Stop();
        }

        // Fire bullet when space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_AudioSource.Play();
            GameObject temp = Instantiate(m_BulletPrefab, m_GunBarrel.transform.position + m_GunBarrel.transform.forward * 0.5f, transform.rotation);
            Rigidbody rb = temp.GetComponent<Rigidbody>();
            rb.velocity = m_GunBarrel.transform.forward * 10.0f;

            Destroy(temp, 3.0f); // Destroy the bullet 3 seconds after it spawns
        }
    }
}
