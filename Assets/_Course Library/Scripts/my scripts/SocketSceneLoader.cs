using UnityEngine;
using UnityEngine.SceneManagement;

public class SocketSceneLoader : MonoBehaviour
{
    [Tooltip("�J�ڐ�̃V�[����")]
    public string sceneName = "game clear";

    [Tooltip("�V�[���J�ڂ܂ł̒x�����ԁi�b�j")]
    public float delaySeconds = 2f;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;

        hasTriggered = true;
        StartCoroutine(LoadSceneWithDelay());
    }

    private System.Collections.IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(sceneName);
    }
}
