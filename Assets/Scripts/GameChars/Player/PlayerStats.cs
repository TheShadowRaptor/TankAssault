using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private int jump;
    public int Health { get => health; }
    public int Speed { get => speed; }
    public int Jump { get => jump; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
