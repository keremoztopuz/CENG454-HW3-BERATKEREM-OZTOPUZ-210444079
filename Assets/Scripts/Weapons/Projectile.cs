using UnityEngine;
using CoreBreach.Interfaces;
using CoreBreach.Pooling;

namespace CoreBreach.Weapons {
    public class Projectile : MonoBehaviour, IPoolable
    {
        [SerializeField] private float projectileDamage = 20f;
        [SerializeField] private float projectileSpeed = 25f;
        [SerializeField] private float lifeTime = 4f;
        private ProjectilePool ownerPool;

        private float remainingLifeTime;
        private Vector3 direction;

        public void Launch(Vector3 startPosition, Vector3 fireDirection, ProjectilePool pool) 
        { //projectile position speed and direction
            transform.position = startPosition;
            direction = fireDirection.normalized;
            remainingLifeTime = lifeTime;
            ownerPool = pool;
            gameObject.SetActive(true);
        }

        private void Update()
        {
            transform.position += direction * projectileSpeed * Time.deltaTime;
            remainingLifeTime -= Time.deltaTime;

            if (remainingLifeTime <= 0f)
            {
                if (ownerPool != null) //return to pool when lifetime expire
                {
                    ownerPool.ReturnProjectile(this);
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }

        public void OnSpawnFromPool()
        {
            remainingLifeTime = lifeTime; //restart projectile lifetime on every reuse
        }
        
        public void OnReturnToPool() //projectile passivise
        {
            direction = Vector3.zero;
        }
        
    }
}   