using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public abstract class CharacterStats : MonoBehaviour
    {
        [Header("Stat Settings")]
        [SerializeField] protected int health;
        protected bool isAlive;

        [Header("Movement Settings")]
        [SerializeField] protected int movementSpeed;

        // Gets/Sets
        public int Health { get => health; }
        //---------------------------------------------------------------
        public int MovementSpeed { get => movementSpeed; }
        //===============================================================

        protected virtual void Update()
        {
            CheckStatus();
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }

        protected void CheckStatus()
        {
            if (health <= 0)
            {
                health = 0;
                isAlive = false;
                Deactivate();
            }
            else
            {
                isAlive = true;
                Activate();
            }
        }

        protected void Deactivate()
        {
            this.gameObject.SetActive(false);
        }

        protected void Activate()
        {
            this.gameObject.SetActive(true);
        }
    }
}
