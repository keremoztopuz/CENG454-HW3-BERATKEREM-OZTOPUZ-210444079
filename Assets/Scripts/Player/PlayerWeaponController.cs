using UnityEngine;
using CoreBreach.Pooling;
using CoreBreach.Weapons;

namespace CoreBreach.Player {

    public class PlayerWeaponController : MonoBehaviour
    {
        [SerializeField] private ProjectilePool projectilePool; //ammo
        [SerializeField] private Transform firePoint; //fire position
        [SerializeField] private float fireRate = 4f; //fire rate by sec

        private float nextFireTime; //next fire 

        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
            {
                Fire();
            }
        }

        private void Fire()
        {
            nextFireTime = Time.time + 1f / fireRate;

            Projectile projectile = projectilePool.GetProjectile();
            projectile.Launch(firePoint.position, firePoint.forward, projectilePool);
        }
    }

}