using UnityEngine;
using CoreBreach.Interfaces;
using System;

namespace CoreBreach.Core
{
    public class CoreHealth: MonoBehaviour, IObjective
    {
        [SerializeField] private float maxHealth = 100f;
        public event Action<float, float> HealthChanged;
        public event Action Destroyed;
        public float CurrentHealth { get; private set;}
        public float MaxHealth => maxHealth;
        public bool IsDestroyed => CurrentHealth <= 0;

        private void Awake()
        {
            CurrentHealth = maxHealth; //initial health
        }

        public void TakeDamage(float amount) 
        {
            if (IsDestroyed) {
                return; 
            } 
            CurrentHealth = Mathf.Max(CurrentHealth - amount, 0f); // core health can't be negative
            HealthChanged?.Invoke(CurrentHealth, maxHealth); // notify for health bar ui

            if (IsDestroyed) // for game over
            {
                Destroyed?.Invoke(); 
            }
        }

    }
}  