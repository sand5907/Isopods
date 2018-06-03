using System.Collections;

namespace Isopods.Interfaces
{
    public interface IShootable
    {
        int ammo { get; set; }
        float timeBetweenShots { get; set; }
        float reloadTime { get; }
        bool reloading { get; }

        void Shoot();
        IEnumerator Reload();
    }
}