using UnityEngine;
using CoreBreach.Core;

namespace CoreBreach.Systems
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private CoreHealth coreHealth;
        private bool isGameOver;

        private void OnEnable()
        {
            if (coreHealth == null)
            {
                return;
            }

            coreHealth.Destroyed += HandleCoreDestroyed;
        }

        private void OnDisable()
        {
            if (coreHealth == null)
            {
                return;
            }

            coreHealth.Destroyed -= HandleCoreDestroyed;
        }

        private void HandleCoreDestroyed()
        {
            if (isGameOver)
            {
                return;
            }

            isGameOver = true;
            Debug.Log("Core destroyed. Mission failed. Try again.");
        }
    }
}
