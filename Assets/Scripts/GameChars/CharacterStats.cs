using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankAssault
{
    public class CharacterStats : MonoBehaviour
    {
        [Header("Stat Settings")]
        [SerializeField] protected int health;

        [Header("Movement Settings")]
        [SerializeField] protected int movementSpeed;

        // Gets/Sets
        public int Health { get => health; }
        //---------------------------------------------------------------
        public int MovementSpeed { get => movementSpeed; }
        //===============================================================
    }
}
