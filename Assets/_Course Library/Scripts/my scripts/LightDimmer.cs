using UnityEngine;
using UnityEngine.SceneManagement;  // シーン遷移に必要

public class LightDimmer : MonoBehaviour
{
    // 初期の光量（任意に設定可能）
    private float initialIntensity;

    // 減衰にかける時間（秒）
    public float duration = 60f;

    // 移動先のシーン名（インスペクターで設定）
    public string sceneToLoad = "game over";

    // 経過時間を記録
    private float elapsedTime = 0f;

    // Light コンポーネント参照
    private Light lightComponent;

    // シーンが遷移されたかのフラグ
    private bool sceneLoaded = false;

    void Start()
    {
        // Light コンポーネントを取得
        lightComponent = GetComponent<Light>();
        if (lightComponent == null)
        {
            Debug.LogError("このオブジェクトにLightコンポーネントが見つかりません。");
            enabled = false;
            return;
        }

        // 初期の光量を保存
        initialIntensity = lightComponent.intensity;
    }

    void Update()
    {
        // 時間を加算
        elapsedTime += Time.deltaTime;

        // 経過時間がdurationを超えないよう制限
        float t = Mathf.Clamp01(elapsedTime / duration);

        // 線形に光量を減少（0まで）
        lightComponent.intensity = Mathf.Lerp(initialIntensity, 0f, t);

        // 経過時間がdurationを超えたらシーン遷移（1回だけ）
        if (!sceneLoaded && elapsedTime-1f >= duration)
        {
            sceneLoaded = true; // 二重呼び出し防止
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
