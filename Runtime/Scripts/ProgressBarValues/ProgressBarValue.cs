using UnityEngine;
using UnityEngine.Events;

namespace Elysium.UI.ProgressBar
{
    public class ProgressBarValue : MonoBehaviour
    {
        public virtual float Max { get; }
        public virtual float Current { get; }

        public event UnityAction OnChanged;

        public virtual void Setup()
        {

        }

        protected virtual void TriggerOnChanged()
        {
            OnChanged?.Invoke();
        }
    }
}