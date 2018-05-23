namespace Isopods.Interfaces
{
    public interface IDamageable
    {
        float health { get; }

        void TakeDamage(float damageTaken);
    }
}

