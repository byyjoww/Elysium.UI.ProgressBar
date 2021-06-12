using System;
using UnityEngine;
using UnityEngine.Events;

namespace Elysium.UI.ProgressBar
{
    public interface IFillable
    {
        float Current { get; }
        float Max { get; }

        event UnityAction OnFillValueChanged;
    }
}