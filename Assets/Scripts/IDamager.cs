public interface IDamager
{
    float Value { get; set; }
    void DoDamage(IDamageable damageable);
}