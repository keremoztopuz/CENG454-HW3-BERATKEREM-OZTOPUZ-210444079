// for weapons

using UnityEngine;

namespace CoreBreach.Interfaces
{
    public interface IWeapon
    {
        float Damage { get; }
        float FireRate { get; }
        
        void Fire(Vector3 origin, Vector3 direction);
    }
}
