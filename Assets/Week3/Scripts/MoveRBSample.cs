using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRBSample : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemies = 8;
    public Vector3 spawnAreaCenter = new Vector3(0.0f, 0.25f, 0.0f);
    public Vector3 spawnAreaSize = new Vector3(7.5f, 0.0f, 5.0f);
    Rigidbody m_Rigidbody;
    Vector3 startPosition;
    List<GameObject> enemies = new List<GameObject>();
    bool isRed = true; // Enemy �̏����F���Ԃ��ǂ������Ǘ�����t���O

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;

        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    void Update()
    {
        if (transform.position.y <= -5.0f)
        {
            transform.position = startPosition;
            ResetVelocity();
            RespawnEnemies();
        }
    }

    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        m_Rigidbody.AddForce(horiz * 10.0f, 0.0f, vert * 10.0f);
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = spawnAreaCenter + new Vector3(Random.Range(-spawnAreaSize.x, spawnAreaSize.x), 0.0f, Random.Range(-spawnAreaSize.z, spawnAreaSize.z));
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemies.Add(enemy);
        // Enemy �̐F��ݒ�
        if (isRed)
        {
            enemy.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            enemy.GetComponent<Renderer>().material.color = new Color(1.0f, 0.5f, 0.0f); // �I�����W�F�ɐݒ�
        }
    }

    void RespawnEnemies()
    {
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear();

        // �F��؂�ւ��Ȃ��� Enemy ���Ĕz�u
        isRed = !isRed; // �F��؂�ւ���
        for (int i = 0; i < numberOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    void ResetVelocity()
    {
        m_Rigidbody.velocity = Vector3.zero;
        m_Rigidbody.angularVelocity = Vector3.zero;
    }
}
