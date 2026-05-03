using UnityEngine;
using CoreBreach.Weapons;
using System.Collections.Generic;

namespace CoreBreach.Pooling
{
    public class ProjectilePool: MonoBehaviour
    {
        [SerializeField] private Projectile projectilePrefab; //bullet prefab
        [SerializeField] private int initialSize = 20; //how many bullets ready

        private readonly Queue<Projectile> availableProjectiles = new(); //holds readytouse projectiles

        private void Awake()
        {
            for (int i = 0; i < initialSize; i++){
                Projectile projectile = CreateProjectile();
                availableProjectiles.Enqueue(projectile);
            }
        }

        private Projectile CreateProjectile() //for creating new projectiles
        {
            Projectile projectile = Instantiate(projectilePrefab, transform);
            projectile.gameObject.SetActive(false);
            return projectile;
        }

        public Projectile GetProjectile() //public method because another class will call this
        {
            Projectile projectile = availableProjectiles.Count > 0

                ? availableProjectiles.Dequeue()
                : CreateProjectile();

            projectile.OnSpawnFromPool();
            projectile.gameObject.SetActive(true);

            return projectile;
        }
        
        public void ReturnProjectile(Projectile projectile)
        {
            projectile.OnReturnToPool();
            projectile.gameObject.SetActive(false);
            availableProjectiles.Enqueue(projectile);
        }
    }
}