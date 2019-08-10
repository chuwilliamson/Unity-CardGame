namespace Chuwilliamson
{
    public interface IDamager
    {
        int Value { get; set; }
        void DoDamage(IDamageable damageable);
    }
}