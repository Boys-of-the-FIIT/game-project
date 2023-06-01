using System;
using Player;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.Scripts
{
    public class Points : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;

        private PlayerEntity player;
        
        [Inject]
        private void Construct(PlayerEntity player)
        {
            this.player = player;
        }
        
        private void Update()
        {
            textMeshPro.text = $"Points: {player.Stats.UpgradePoints}";
        }
    }
}