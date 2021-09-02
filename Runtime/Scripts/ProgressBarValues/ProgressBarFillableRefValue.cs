using Elysium.Core;
using Elysium.Utils.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Elysium.UI.ProgressBar
{
    public class ProgressBarFillableRefValue : ProgressBarValue
    {
        [RequireInterface(typeof(IFillable))]
        [SerializeReference] private UnityEngine.Object fillable = default;

        public IFillable Fillable => fillable as IFillable;

        public override float Max => Fillable.Max;
        public override float Current => Fillable.Current;

        public override void Setup()
        {
            if (Fillable == null) { throw new System.Exception("fillable not set in inspector"); }

            Fillable.OnFillValueChanged += TriggerOnChanged;
            TriggerOnChanged();
        }
    }
}