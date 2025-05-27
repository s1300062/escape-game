using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToGrid : MonoBehaviour
{
    public float gridSize = 0.5f;          // 位置スナップの間隔
    public float rotationSnap = 90.0f;     // 回転スナップの角度

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnRelease(SelectExitEventArgs args)
    {
        SnapPosition();
        SnapRotation();
    }

    void SnapPosition()
    {
        Vector3 pos = transform.position;
        float x = Mathf.Round(pos.x / gridSize) * gridSize;
        float y = Mathf.Round(pos.y / gridSize) * gridSize;
        float z = Mathf.Round(pos.z / gridSize) * gridSize;
        transform.position = new Vector3(x, y, z);
    }

    void SnapRotation()
    {
        Vector3 euler = transform.eulerAngles;
        float x = Mathf.Round(euler.x / rotationSnap) * rotationSnap;
        float y = Mathf.Round(euler.y / rotationSnap) * rotationSnap;
        float z = Mathf.Round(euler.z / rotationSnap) * rotationSnap;
        transform.rotation = Quaternion.Euler(x, y, z);
    }

    void OnDestroy()
    {
        if (grabInteractable != null)
            grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
