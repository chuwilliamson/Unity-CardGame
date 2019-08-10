using UnityEngine;

namespace Chuwilliamson
{
    public class Damager : IDamager
    {
        [field: SerializeField]
        public int Value { get; set; }

        public void DoDamage(IDamageable damageable)
        {
            damageable.TakeDamage(Value);
        }
    }
}
