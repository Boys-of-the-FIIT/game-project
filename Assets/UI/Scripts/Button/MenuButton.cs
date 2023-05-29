using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Scripts
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshPro;
        private Color originalColor;

        private void Start()
        {
            originalColor = textMeshPro.color;
        }

        public void OnPointerEnter()
        {
            textMeshPro.color = Color.red;
        }

        public void OnPointerExit()
        {
            textMeshPro.color = originalColor;
        }
    }
}