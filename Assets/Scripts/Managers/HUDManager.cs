using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Slider JumpChargeSlider;
    public PlayerStats _playerStats;

    // Start is called before the first frame update
    void Start()
    {
        InitSliders();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSliders();
    }

    void InitSliders()
    {
        JumpChargeSlider.maxValue = _playerStats.BaseJumpCharge;
        JumpChargeSlider.value = _playerStats.JumpCharge;
    }

    void UpdateSliders()
    {
        JumpChargeSlider.value = _playerStats.JumpCharge;
    }
}
