using UnityEngine;
using UnityEngine.SceneManagement;

public class SocketSceneLoader : MonoBehaviour
{
    [Tooltip("‘JˆÚæ‚ÌƒV[ƒ“–¼")]
    public string sceneName = "game clear";

    [Tooltip("ƒV[ƒ“‘JˆÚ‚Ü‚Å‚Ì’x‰„ŠÔi•bj")]
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
