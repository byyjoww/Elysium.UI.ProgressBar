using Elysium.Core;
using Elysium.Utils;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Elysium.UI.ProgressBar
{
    public class ProgressBarData : IFillable
    {
        public ProgressBarData(Func<float> _current, Func<float> _max)
        {
            CurrentFill = new RefValue<float>(_current);
            MaxFill = new RefValue<float>(_max);
        }

        public RefValue<float> CurrentFill;
        public RefValue<float> MaxFill;

        public float Current => Mathf.Clamp(CurrentFill.Value, 0, Max);
        public float Max => MaxFill.Value;


        public event UnityAction OnFillValueChanged;

        public void TriggerOnFillValueChanged()
        {
            OnFillValueChanged?.Invoke();
        }
    }
}
