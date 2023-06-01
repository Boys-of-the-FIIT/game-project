using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    [SerializeField] private Text levelText;
    [SerializeField] private Image expBarImage;

    private int level = 1;
    private int experience;

    private void Start()
    {
        AddExperience(3);
     //   expBarImage.fillAmount = 0.5f;
    }

    private static int ExpNeedToLevelUp(int currentLevel)
    {
        if (currentLevel == 0) return 1;

        return (currentLevel * currentLevel + currentLevel) * 5;
    }

    public void AddExperience(int exp)
    {
        experience += exp;

        while (true)
        {
            var expNeeded1 = ExpNeedToLevelUp(level);
            var prevExp1 = ExpNeedToLevelUp(level - 1);
        }
        
        var expNeeded = ExpNeedToLevelUp(level);
        var prevExp = ExpNeedToLevelUp(level - 1);

        if (experience >= expNeeded)
        {
            IncrementLevel();
            expNeeded = ExpNeedToLevelUp(level);
            prevExp = ExpNeedToLevelUp(level - 1);
        }

        expBarImage.fillAmount = (float)(experience - prevExp) / (expNeeded - prevExp);


        Debug.Log(expBarImage.fillAmount);
        
        
        if (expBarImage.fillAmount == 1)
        {
            expBarImage.fillAmount = 0;
        }
    }

    private void IncrementLevel()
    {
        level++;
        levelText.text = level.ToString("");
    }
}