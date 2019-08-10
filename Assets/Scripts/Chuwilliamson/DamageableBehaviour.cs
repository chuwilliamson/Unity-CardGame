using UnityEngine;
using UnityEngine.Events;

namespace Chuwilliamson
{
    public class DamageableBehaviour : MonoBehaviour, IDamageable
    {
        [SerializeField] private IntVariable health;

#pragma warning disable 649
        [SerializeField] private UnityEvent response;
#pragma warning restore 649
        [SerializeField] private UnityEvent responseDead;

        public void TakeDamage(int amount)
        {
            var newValue = health.Value - amount;

            health.Value = newValue;

            response.Invoke();

            if (newValue <= 0)
                responseDead.Invoke();
        }

        // Start is called before the first frame update
        private void Start()
        {
            health = Instantiate(health);
        }
    }
}