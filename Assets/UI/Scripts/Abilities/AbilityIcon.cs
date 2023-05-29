using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Abilities;
using UnityEngine;
using UnityEngine.UI;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] private Ability ability;
    [SerializeField] private Slider sliderBar;
    
    private void Update()
    {
        sliderBar.value = ability.CurrentCooldownTimes / ability.CoolDown;
    }
}
