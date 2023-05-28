using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Scripts
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Color hoverColor;
        
        private ColorBlock colorBlock;
        private Color originalColor;

        private void Start()
        {
            colorBlock = button.colors;
            originalColor = colorBlock.selectedColor;
        }

        public void OnPointerEnter()
        {
            colorBlock.selectedColor = hoverColor;
            button.colors = colorBlock;
        }
        
        public void OnPointerExit()
        {
            colorBlock.selectedColor = originalColor;
            button.colors = colorBlock;
        }
    }
}