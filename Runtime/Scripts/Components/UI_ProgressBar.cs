using System;
using UnityEngine;
using UnityEngine.UI;

namespace Elysium.UI.ProgressBar
{
    public class UI_ProgressBar : MonoBehaviour
    {
        [SerializeField] protected bool disableOnEmpty = false;

        [Header("Value")]
        [SerializeField] protected ProgressBarValue Value;

        [Header("Fill Component")]
        [SerializeField] protected Image fillImageComponent;

        [Header("Color")]
        [SerializeField] protected Image colorImageComponent;
        [SerializeField] protected Gradient gradient;

        [Header("Text Components")]
        [SerializeField] protected Text percentageTextComponent;
        [SerializeField] protected Text flatValueTextComponent;

        public void BindCustomValue(Func<float> _getCurrent, Func<float> _getMax, ref Action _onChanged)
        {
            if (Value == null)
            {
                Value = gameObject.AddComponent<ProgressBarFillableValue>();
            }

            if (Value.GetType() != typeof(ProgressBarFillableValue))
            {
                Destroy(Value);
                Value = gameObject.AddComponent<ProgressBarFillableValue>();
            }

            var data = new ProgressBarData(_getCurrent, _getMax);            
            (Value as ProgressBarFillableValue).SetRuntimeData(data);
            _onChanged += () => data.TriggerOnFillValueChanged();
            Value.OnChanged += UpdateValue;
            UpdateValue();
        }

        public void SetActive(bool _active)
        {
            gameObject.SetActive(_active);
        }

        public virtual float Fill
        {
            get
            {
                if (Value.Max == -1) { return -1; }
                if (Value.Max == 0) { return 0; }
                return Value.Current / Value.Max;
            }
        }

        protected virtual string barPercentageText => $"{Mathf.Clamp(Fill * 100, 0, 100).ToString("0")}%";

        protected virtual string barFlatValueText => $"{Value.Current}/{Value.Max}";

        protected virtual Color barColor => gradient.Evaluate(Fill);

        protected virtual float barFill => Fill;

        private void Start()
        {
            Value.Setup();
            Value.OnChanged += UpdateValue;
            UpdateValue();
        }

        private void UpdateValue()
        {
            if (percentageTextComponent != null) { percentageTextComponent.text = barPercentageText; }
            if (flatValueTextComponent != null) { flatValueTextComponent.text = barFlatValueText; }
            if (fillImageComponent != null) { fillImageComponent.fillAmount = barFill; }
            if (colorImageComponent != null) { colorImageComponent.color = barColor; }

            if (Fill == 0) { SetActive(!disableOnEmpty); }
            else if(Fill == -1) { SetActive(!disableOnEmpty); }
            else { SetActive(true); }
        }

        private void OnValidate()
        {
            if (Value == null) { Value = gameObject.AddComponent<ProgressBarFillableValue>(); }
            colorImageComponent.color = gradient.Evaluate(1);
        }
    }
}