using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private int health;
    [SerializeField] private int movementSpeed;
    [SerializeField] private int rotationSpeedTurret;
    [SerializeField] private int jumpPower;
    [SerializeField] private bool jumpFullyCharged;

    [Header("JumpCharge Settings")]
    [SerializeField] private float maxJumpCharge;
    private float jumpCharge;

    // Gets/Sets
    public int Health { get => health; }
    public int MovementSpeed { get => movementSpeed; }
    public int RotationSpeedTurret { get => rotationSpeedTurret; }
    public int JumpPower { get => jumpPower; }
    public float MaxJumpCharge { get => maxJumpCharge; }
    public float JumpCharge { get => jumpCharge; }
    public bool JumpFullyCharged { get => jumpFullyCharged; }

    // Varibles
    

    // Start is called before the first frame update
    void Start()
    {
        // init
        jumpCharge = maxJumpCharge;
    }

    private void Update()
    {
        ManageJumpCharge();
    }

    void ManageJumpCharge()
    {
        float chargeIncrease = 0.5f;

        jumpCharge += chargeIncrease * Time.deltaTime;
        if (jumpCharge >= maxJumpCharge)
        {
            jumpCharge = maxJumpCharge;
            jumpFullyCharged = true;
        }
        else jumpFullyCharged = false;
    }

    public void ResetJumpCharge()
    {
        jumpCharge = 0;
    }
}
