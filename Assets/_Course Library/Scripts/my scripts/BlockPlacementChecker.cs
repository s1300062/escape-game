using UnityEngine;

public class BlockPlacementChecker : MonoBehaviour
{
    public Transform block1;
    public Transform block2;
    public Vector3 targetPosition1;
    public Quaternion targetRotation1;
    public Vector3 targetPosition2;
    public Quaternion targetRotation2;

    public float positionTolerance = 0.05f;
    public float rotationTolerance = 5f;

    public ParticleSystem clearEffectPrefab; // クリア時のエフェクト
    public AudioClip clearSound;             // クリア時の効果音

    private bool isCleared = false;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (!isCleared)
        {
            bool block1Correct = IsBlockCorrect(block1, targetPosition1, targetRotation1);
            bool block2Correct = IsBlockCorrect(block2, targetPosition2, targetRotation2);

            Debug.Log($"block1 correct: {block1Correct}, block2 correct: {block2Correct}");

            if (block1Correct && block2Correct)
            {
                isCleared = true;
                Debug.Log("クリア！");

                TriggerClearEffect(block1.position);
                TriggerClearEffect(block2.position);

                LockBlock(block1);
                LockBlock(block2);
            }
        }
    }

    private bool IsBlockCorrect(Transform block, Vector3 targetPos, Quaternion targetRot)
    {
        float posDiff = Vector3.Distance(block.position, targetPos);
        float rotDiff = Quaternion.Angle(block.rotation, targetRot);

        Debug.Log($"{block.name} - Position: {block.position}, Target: {targetPos}, PosDiff: {posDiff:F4}, RotDiff: {rotDiff:F2}");

        return posDiff <= positionTolerance && rotDiff <= rotationTolerance;
    }

    private void TriggerClearEffect(Vector3 position)
    {
        if (clearEffectPrefab != null)
        {
            Instantiate(clearEffectPrefab, position, Quaternion.identity);
        }

        if (clearSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(clearSound);
        }
    }

    private void LockBlock(Transform block)
    {
        var rb = block.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
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
