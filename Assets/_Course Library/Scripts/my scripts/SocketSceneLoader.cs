using UnityEngine;
using UnityEngine.SceneManagement;

public class SocketSceneLoader : MonoBehaviour
{
    [Tooltip("遷移先のシーン名")]
    public string sceneName = "game clear";

    [Tooltip("シーン遷移までの遅延時間（秒）")]
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
