using UnityEngine;
using UnityEngine.SceneManagement;

public class SocketSceneLoader : MonoBehaviour
{
    [Tooltip("�J�ڐ�̃V�[����")]
    public string sceneName = "game clear";

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        hasTriggered = true;
        SceneManager.LoadScene(sceneName);
    }
}
