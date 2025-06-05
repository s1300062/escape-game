using UnityEngine;

public class AmbientIntensityChanger : MonoBehaviour
{
    public float targetIntensity = 8.0f;       // 変化後の明るさ
    public float duration = 2.0f;              // 変化にかける時間（秒）
    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasTriggered) return;
        hasTriggered = true;

        StartCoroutine(ChangeAmbientIntensity());
    }

    private System.Collections.IEnumerator ChangeAmbientIntensity()
    {
        float startIntensity = RenderSettings.ambientIntensity;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            RenderSettings.ambientIntensity = Mathf.Lerp(startIntensity, targetIntensity, t);
            yield return null;
        }

        RenderSettings.ambientIntensity = targetIntensity; // 最終値で固定
    }
}
