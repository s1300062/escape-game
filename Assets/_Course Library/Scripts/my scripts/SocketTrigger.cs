using UnityEngine;

public class SocketTrigger : MonoBehaviour
{
    public LightDimmer lightDimmer; // 対象のライトの参照（インスペクターで設定）

    void OnTriggerEnter(Collider other)
    {
        // 条件に応じてフィルタ可能（例: 特定タグの物体など）
        if (lightDimmer != null)
        {
            lightDimmer.TriggerLightIncrease();
        }
    }
}
