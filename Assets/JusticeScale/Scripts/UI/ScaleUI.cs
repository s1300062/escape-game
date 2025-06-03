using System;
using JusticeScale.Scripts.Scales;
using UnityEngine;
using UnityEngine.UI;

namespace JusticeScale.Scripts.UI
{
    public class ScaleUI : MonoBehaviour
    {
        [SerializeField] private Scale scale; // Reference to the Scale component
        [SerializeField] private Text balanceText;

        [SerializeField] private bool isInPounds;

        private bool hasCleared = false; // ✅ 一度だけ加算するためのフラグ

        private void Awake()
        {
            if (scale == null) scale = GetComponentInParent<TriggerScale>();
            if (balanceText == null) balanceText = GetComponentInChildren<Text>();
        }

        private void Update()
        {
            float weight = scale.TotalWeight;

            // 表示更新
            balanceText.text = isInPounds
                ? $"{ConvertKgToPound(weight)} pounds"
                : $"{weight} kg";

            // ✅ 重さが7になったときに一度だけカウント追加
            if (!hasCleared && Mathf.Approximately(weight, 7f))
            {
                hasCleared = true;
                ClearChecker.clearCount++;
                Debug.Log("Weight reached 7kg — clearCount increased!");
            }
        }

        private float ConvertKgToPound(float massKg)
        {
            var poundConverse = massKg * 2.20f;
            return (float)Math.Round(poundConverse, 2);
        }
    }
}
