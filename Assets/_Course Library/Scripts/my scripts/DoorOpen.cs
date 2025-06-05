using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject door;              // ��]������h�A�I�u�W�F�N�g
    public float openAngle = 90f;        // �J���p�x
    public float openSpeed = 2f;         // �J�����x

    private bool isOpened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isOpened) return; // ��x�����J��
        isOpened = true;

        if (door != null)
        {
            StartCoroutine(OpenDoor());
        }
    }

    System.Collections.IEnumerator OpenDoor()
    {
        Quaternion startRot = door.transform.rotation;
        Quaternion endRot = startRot * Quaternion.Euler(0, openAngle, 0);
        float elapsed = 0f;

        while (elapsed < 1f)
        {
            elapsed += Time.deltaTime * openSpeed;
            door.transform.rotation = Quaternion.Slerp(startRot, endRot, elapsed);
            yield return null;
        }
    }
}

