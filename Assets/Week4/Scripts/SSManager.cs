using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSManager : MonoBehaviour
{
    public GameObject SS; // SSオブジェクトの参照
    public GameObject bulletPrefab; // BulletのPrefab
    public float moveSpeed = 5.0f; // 移動速度
    public AudioClip fireSound; // 発射時の効果音

    private AudioSource audioSource; // 効果音を再生するための AudioSource コンポーネント

    // Start is called before the first frame update
    void Start()
    {
        // SSオブジェクトを名前で検索して取得
        if (SS == null)
        {
            SS = GameObject.Find("SS");
        }
        
        if (SS == null)
        {
            Debug.LogError("SSという名前のオブジェクトが見つかりませんでした。");
        }

        // AudioSource コンポーネントを取得
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource コンポーネントがアタッチされていません。");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SS != null)
        {
            // 矢印キーの入力を取得
            float moveX = Input.GetAxis("Horizontal"); // 左右の入力
            float moveZ = Input.GetAxis("Vertical"); // 前後の入力

            // 移動するベクトルを計算
            Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;

            // SSオブジェクトの位置を更新
            SS.transform.Translate(move, Space.World);

            // Spaceキーが押されたらBulletを発射
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireBullet();
            }
        }
    }

    // Bulletを発射するメソッド
    void FireBullet()
    {
        if (bulletPrefab != null && SS != null)
        {
            // Bulletの発射位置を計算
            Vector3 spawnPosition = SS.transform.position + SS.transform.forward;

            // Bulletを生成して発射
            GameObject bulletObject = Instantiate(bulletPrefab, spawnPosition, SS.transform.rotation);

            // BulletのRigidbodyコンポーネントを取得
            Rigidbody bulletRigidbody = bulletObject.GetComponent<Rigidbody>();

            // Bulletが動くように速度を設定（ここではZ軸方向に10の速度を設定）
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = SS.transform.forward * 10f;
            }
            else
            {
                Debug.LogError("BulletにRigidbodyコンポーネントがアタッチされていません。");
            }

            // 効果音を再生
            if (audioSource != null && fireSound != null)
            {
                audioSource.PlayOneShot(fireSound);
            }
            else
            {
                Debug.LogError("AudioSourceまたは効果音が設定されていません。");
            }
        }
    }
}
