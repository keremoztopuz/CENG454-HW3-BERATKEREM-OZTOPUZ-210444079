using UnityEngine;
using CoreBreach.Interfaces;

namespace CoreBreach.Weapons {
    public class Projectile : MonoBehaviour, IPoolable
    {
        [SerializeField] private float projectileDamage = 20f;
        [SerializeField] private float projectileSpeed = 25f;
        [SerializeField] private float lifeTime = 4f;

        private float remainingLifeTime;
        private Vector3 direction;

        public void Launch(Vector3 startPosition, Vector3 fireDirection) 
        { //projectile position speed and direction
            transform.position = startPosition;
            direction = fireDirection.normalized;
            remainingLifeTime = lifeTime;
            gameObject.SetActive(true);
        }

        private void Update()
        {
            transform.position += direction * projectileSpeed * Time.deltaTime;
            remainingLifeTime -= Time.deltaTime;

            if (remainingLifeTime <= 0f)
            {
                gameObject.SetActive(false); //until pool we keep reuse like this
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