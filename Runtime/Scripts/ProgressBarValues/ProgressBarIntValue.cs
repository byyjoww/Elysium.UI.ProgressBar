using Elysium.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elysium.UI.ProgressBar
{
    public class ProgressBarIntValue : ProgressBarValue
    {
        [SerializeField] private IntValueSO current = default;
        [SerializeField] private IntValueSO max = default;

        public override float Max => max.Value;

        public override float Current => current.Value;

        public override void Setup()
        {
            if (max != null) { max.OnValueChanged += TriggerOnChanged; }
            if (current != null) { current.OnValueChanged += TriggerOnChanged; }
        }
    }
}