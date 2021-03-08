using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elysium.UI.ProgressBar
{
    public class UI_CountdownBar : UI_ProgressBar
    {
        public override float Fill
        {
            get
            {
                if (Value.Max == -1) { return -1; }
                if (Value.Max == 0) { return 0; }
                return (Value.Max - Value.Current) / Value.Max;
            }
        }

        protected override string barPercentageText
        {
            get
            {
                if (Fill == -1) { return "Failed"; }
                return $"{Mathf.Clamp(Fill * 100, 0, 100).ToString("0")}%";
            }
        }

        protected override string barFlatValueText
        {
            get
            {
                if (Fill == -1) { return "Failed"; }
                return $"{Value.Current}/{Value.Max}";
            }
        }

        protected override Color barColor
        {
            get
            {
                if (Fill == -1) { return Color.red; }
                return gradient.Evaluate(Fill);
            }
        }

        protected override float barFill
        {
            get
            {
                if (Fill == -1) { return 1; }
                return Fill;
            }
        }
    }
}