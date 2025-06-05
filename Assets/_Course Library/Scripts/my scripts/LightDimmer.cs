using UnityEngine;
using UnityEngine.SceneManagement;

public class LightDimmer : MonoBehaviour
{
    private float initialIntensity;
    public float duration = 60f;
    public string sceneToLoad = "game over";
    private float elapsedTime = 0f;
    private Light lightComponent;
    private bool sceneLoaded = false;

    // --- 追加パラメータ ---
    public float maxIntensity = 2f;
    public float increaseDuration = 5f;

    private bool dimmingStopped = false;
    private bool isIncreasing = false;
    private float increaseTime = 0f;

    void Start()
    {
        lightComponent = GetComponent<Light>();
        if (lightComponent == null)
        {
            Debug.LogError("このオブジェクトにLightコンポーネントが見つかりません。");
            enabled = false;
            return;
        }

        initialIntensity = lightComponent.intensity;
    }

    void Update()
    {
        if (!dimmingStopped && !isIncreasing)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            lightComponent.intensity = Mathf.Lerp(initialIntensity, 0f, t);

            if (!sceneLoaded && elapsedTime - 1f >= duration)
            {
                sceneLoaded = true;
                SceneManager.LoadScene(sceneToLoad);
            }
        }
        else if (isIncreasing)
        {
            increaseTime += Time.deltaTime;
            float t = Mathf.Clamp01(increaseTime / increaseDuration);
            lightComponent.intensity = Mathf.Lerp(lightComponent.intensity, maxIntensity, t);

            if (t >= 1f)
            {
                isIncreasing = false;
            }
        }
    }

    // --- ソケットから呼び出されるメソッド ---
    public void TriggerLightIncrease()
    {
        dimmingStopped = true;
        isIncreasing = true;
        increaseTime = 0f;
    }
}
