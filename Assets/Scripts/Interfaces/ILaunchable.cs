using UnityEngine;

namespace Isopods.Interfaces
{
    public interface ILaunchable : IShootable
    {
        GameObject projectile { get; }
        
        float projectileSpeed { get; set; }
    }
}

