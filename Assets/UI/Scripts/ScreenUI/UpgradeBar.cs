using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using Player;
using TMPro;
using UI.Scripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Upgrades;
using Zenject;

public class UpgradeBar : MonoBehaviour
{
    [SerializeField] private string upgradeName;
    [SerializeField] private Color upgradeSectionColor;
    [SerializeField] private List<UpgradeSection> upgradeSections;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private UnityEvent<float> clickEvent;
    [SerializeField] private TextMeshProUGUI upgradeTextMeshPro;
    [SerializeField] private float upgradeBonus;
    [SerializeField] private float startPoints;
    [SerializeField] private float increasePoints;


    private List<Image> images;
    private List<TextMeshProUGUI> textMeshes;
    private int currentUpgradeIndex;
    private PlayerEntity player;
    private Stats playerStats;

    private UpgradeSection nextUpgrade => upgradeSections[currentUpgradeIndex + 1];

    [Inject]
    private void Construct(PlayerEntity playerEntity)
    {
        this.player = playerEntity;
        this.playerStats = playerEntity.Stats;
    }

    private void Awake()
    {
        images = GetComponentsInChildren<Image>().ToList();
        textMeshes = GetComponentsInChildren<TextMeshProUGUI>().ToList();
        currentUpgradeIndex = -1;
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
        var requiredPoints = startPoints;
        upgradeSections.ForEach(section =>
        {
            section.GetComponent<Image>().color = Color.grey;
            section.GivenBonus = upgradeBonus;
            section.RequiredPoints = requiredPoints;
            requiredPoints += increasePoints;
        });
    }

    private void OnUpgradeButtonClick()
    {
        if (currentUpgradeIndex <= upgradeSections.Count - 1)
        {
            if (playerStats.UpgradePoints >= nextUpgrade.RequiredPoints)
            {
                nextUpgrade.GetComponent<Image>().color = upgradeSectionColor;
                clickEvent.Invoke(nextUpgrade.GivenBonus);
                playerStats.UpgradePoints -= nextUpgrade.RequiredPoints;
                currentUpgradeIndex++;
            }
        }
    }

    private void Update()
    {
        UpdateSprites(playerStats.UpgradePoints >= nextUpgrade.RequiredPoints);
    }

    private void UpdateSprites(bool expose)
    {
        images.ForEach(image => image.enabled = expose);
        textMeshes.ForEach(textMesh => textMesh.enabled = expose);
    }
}