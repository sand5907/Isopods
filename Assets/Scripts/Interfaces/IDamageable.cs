namespace Isopods.Interfaces
{
    public interface IDamageable
    {
        float health { get; set; }

        void TakeDamage(float damageTaken);
    }
}

