using Elysium.UI.ProgressBar;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarTest : MonoBehaviour
{
    [SerializeField] private UI_ProgressBar progressBar = default;

    public float current = 0;
    public float max = 10;

    public event Action OnValueChanged;

    [ContextMenu("Bind Data")]
    private void BindData()
    {
        progressBar.BindCustomValue(() => current, () => max, ref OnValueChanged);
    }

    [ContextMenu("Random Fill")]
    private void FillRandomValue()
    {
        var r = UnityEngine.Random.Range(0f, 2f);
        current += r;
        OnValueChanged?.Invoke();
    }
}
