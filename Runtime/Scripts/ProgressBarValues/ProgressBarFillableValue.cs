using Elysium.Utils.Attributes;
using UnityEngine;

namespace Elysium.UI.ProgressBar
{
    public class ProgressBarFillableValue : ProgressBarValue
    {
        protected IFillable runtimeData;

        public override float Max => runtimeData.Max;
        public override float Current => runtimeData.Current;

        public override void Setup()
        {
            if (runtimeData == null) { runtimeData = new ProgressBarData(() => 0, () => 0); }
            runtimeData.OnFillValueChanged += TriggerOnChanged;
            TriggerOnChanged();
        }

        public void SetRuntimeData(IFillable _data)
        {
            if (runtimeData != null) { runtimeData.OnFillValueChanged -= TriggerOnChanged; }
            runtimeData = _data;
            Setup();
        }
    }
}