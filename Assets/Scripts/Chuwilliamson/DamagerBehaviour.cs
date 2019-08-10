using System;
using UnityEngine;

namespace Chuwilliamson
{
    public class DamagerBehaviour : MonoBehaviour, IDamager
    {
        [SerializeField] private IntVariable attack;

        [SerializeField]
        private UnityEngine.Events.UnityEvent response;
        public int Value
        {
            get => attack.Value;
            set => attack.Value = value;
        }

        public void DoDamage(IDamageable damageable)
        {
            damageable.TakeDamage(attack.Value);
            response.Invoke();
        }
    }
}