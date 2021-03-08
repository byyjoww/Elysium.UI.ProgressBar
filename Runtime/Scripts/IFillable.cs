using System;
using UnityEngine;

namespace Elysium.UI.ProgressBar
{
    public interface IFillable
    {
        float Current { get; }
        float Max { get; }
        event Action OnFillValueChanged;
        void TriggerOnFillValueChanged();
    }
}