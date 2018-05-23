using System.Collections;

namespace Isopods.Interfaces
{
    public interface IShootable
    {
        int ammo { get; set; }
        float timeBetweenShots { get; set; }

         void Shoot();
    }
}