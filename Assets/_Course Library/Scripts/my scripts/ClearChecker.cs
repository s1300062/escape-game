using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearChecker : MonoBehaviour
{
    public Transform block1;
    public Transform block2;
    public Vector3 targetPosition1;
    public Quaternion targetRotation1;
    public Vector3 targetPosition2;
    public Quaternion targetRotation2;

    public float positionTolerance = 0.05f;
    public float rotationTolerance = 5f;

    public ParticleSystem clearEffectPrefab;
    public AudioClip clearSound;
    public GameObject exitKeyPrefab; // 🔑 脱出用の鍵プレハブ
    public Transform keySpawnPoint;  // 🔑 鍵の出現位置

    public static int clearCount = 0; // 全体のクリア回数カウント
    private static bool keySpawned = false;
    private bool isCleared = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    void Update()
    {
        // ブロッククリア判定
        if (!isCleared)
        {
            bool block1Correct = IsBlockCorrect(block1, targetPosition1, targetRotation1);
            bool block2Correct = IsBlockCorrect(block2, targetPosition2, targetRotation2);

            if (block1Correct && block2Correct)
            {
                isCleared = true;
                Debug.Log("クリア！");

                TriggerClearEffect(block1.position);
                TriggerClearEffect(block2.position);

                LockBlock(block1);
                LockBlock(block2);

                clearCount++;
                Debug.Log($"全体クリア数: {clearCount}");
            }
        }

        // 鍵生成は別で監視する（最後にブロックでなくても生成されるように）
        if (!keySpawned && clearCount == 2)
        {
            if (exitKeyPrefab != null && keySpawnPoint != null)
            {
                Instantiate(exitKeyPrefab, keySpawnPoint.position, keySpawnPoint.rotation);
                Debug.Log("🔑 鍵を生成しました！");
            }
            else
            {
                Debug.LogWarning("鍵プレハブまたはスポーン地点が設定されていません！");
            }

            keySpawned = true;
        }
    }

    private bool IsBlockCorrect(Transform block, Vector3 targetPos, Quaternion targetRot)
    {
        float posDiff = Vector3.Distance(block.position, targetPos);
        float rotDiff = Quaternion.Angle(block.rotation, targetRot);
        return posDiff <= positionTolerance && rotDiff <= rotationTolerance;
    }

    private void TriggerClearEffect(Vector3 position)
    {
        if (clearEffectPrefab != null)
            Instantiate(clearEffectPrefab, position, Quaternion.identity);

        if (clearSound != null && audioSource != null)
            audioSource.PlayOneShot(clearSound);
    }

    private void LockBlock(Transform block)
    {
        var rb = block.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }

        var grab = block.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
        if (grab != null)
        {
            grab.enabled = false; // XR Grab Interactable を無効にする
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (block1 != null)
        {
            Gizmos.DrawSphere(block1.position, 0.025f);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(targetPosition1, Vector3.one * 0.5f);
            Gizmos.DrawLine(block1.position, targetPosition1);
        }

        Gizmos.color = Color.cyan;
        if (block2 != null)
        {
            Gizmos.DrawSphere(block2.position, 0.025f);
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(targetPosition2, Vector3.one * 0.5f);
            Gizmos.DrawLine(block2.position, targetPosition2);
        }
    }
}

