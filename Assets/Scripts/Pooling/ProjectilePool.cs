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
                CreateProjectile();
            }
        }

        private Projectile CreateProjectile() //for creating new projectiles
        {
            Projectile projectile = Instantiate(projectilePrefab, transform);
            projectile.gameObject.SetActive(false);
            availableProjectiles.Enqueue(projectile);
            return projectile;
        }
    }
}