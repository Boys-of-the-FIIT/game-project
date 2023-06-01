using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UI.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Upgrades;

public class UpgradeBar : MonoBehaviour
{
    [SerializeField] private Color defaultColor;
    [SerializeField] private Image[] upgradeSections;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private UnityEvent clickEvent;

    private float currentUpgradeIndex;
    private PlayerEntity player;
    
    private void Construct(PlayerEntity playerEntity)
    {
        this.player = playerEntity;
    }
    
    private void OnUpgradeButtonClick()
    {
        
    }
}
