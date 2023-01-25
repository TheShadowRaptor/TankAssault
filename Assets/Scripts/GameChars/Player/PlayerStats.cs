using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Resets
    private float baseShootingTimer;
    private float baseJumpCharge;

    // Variables
    [Header("Stat Settings")]
    [SerializeField] private int health;

    [Header("Movement Settings")]
    [SerializeField] private int movementSpeed;
    [SerializeField] private int rotationSpeedTurret;
    [SerializeField] private int jumpPower;

    [Header("JumpCharge Settings")]
    private float jumpCharge;
    private bool jumpFullyCharged;

    [Header("ShootingSettings")]
    [SerializeField] private float shootingTimer;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private float bulletPower;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool canShoot;


    // Gets/Sets
    public int Health { get => health; }
    //---------------------------------------------------------------
    public int MovementSpeed { get => movementSpeed; }
    public int RotationSpeedTurret { get => rotationSpeedTurret; }
    public int JumpPower { get => jumpPower; }
    //---------------------------------------------------------------
    public float BaseJumpCharge { get => baseJumpCharge; }
    public float JumpCharge { get => jumpCharge; }
    public bool JumpFullyCharged { get => jumpFullyCharged; }
    //---------------------------------------------------------------
    public float ShootingTimer { get => shootingTimer; }
    public float ShootingSpeed { get => shootingSpeed; }
    public float BulletPower { get => bulletPower; }
    public float BulletSpeed { get => bulletSpeed; }
    public bool CanShoot { get => canShoot; }
    //===============================================================

    // Start is called before the first frame update
    void Start()
    {
        // init
        baseJumpCharge = jumpCharge;
        baseShootingTimer = shootingTimer;
    }

    private void Update()
    {
        HandleJumpCharge();
        HandleShootingTimer();
    }

    void HandleJumpCharge()
    {
        float chargeIncrease = 0.5f;

        jumpCharge += chargeIncrease * Time.deltaTime;
        if (jumpCharge >= baseJumpCharge)
        {
            jumpCharge = baseJumpCharge;
            jumpFullyCharged = true;
        }
        else jumpFullyCharged = false;
    }


    void HandleShootingTimer()
    {
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0)
        {
            shootingTimer = 0;
            canShoot = true;
        }
        else canShoot = false;
    }

    public void ResetJumpCharge()
    {
        jumpCharge = 0;
    }

    public void ResetShootingTimer()
    {
        shootingTimer = baseShootingTimer;
    }
}
