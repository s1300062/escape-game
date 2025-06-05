using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public GameObject door;              // 回転させるドアオブジェクト
    public float openAngle = 90f;        // 開く角度
    public float openSpeed = 2f;         // 開く速度

    private bool isOpened = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isOpened) return; // 一度だけ開く
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

