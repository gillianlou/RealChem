//DrawerController.cs implements the functionality for the drawer that appears in the app when you click the up arrow. This script allows you to create 
//new elements within the Uniity editor, setting their colors and symbols

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace RealChem.UI
{
    public class DrawerController : MonoBehaviour
    {
        [SerializeField]
        private ElementDefinition[] _avaliableElements;
        private ElementDefinition[] AvailableElements => _avaliableElements;

        [Space]

        [SerializeField]
        private ElementIcon _iconPrefab;
        private ElementIcon IconPrefab => _iconPrefab;

        [SerializeField]
        private RectTransform _content;
        private RectTransform Content => _content;

        [Space]

        [SerializeField]
        private GameObject _closeDrawerButton;
        private GameObject CloseDrawerButton => _closeDrawerButton;

        [SerializeField]
        private GameObject _drawerButton;
        private GameObject DrawerButton => _drawerButton;
        private RectTransform RectTransform => transform as RectTransform;

        private void Start()
        {
            for(int i = 0, n = AvailableElements.Length; i <n; i++)
            {
                var element = AvailableElements[i];
                var icon = Instantiate(IconPrefab, Content);
                icon.Definition = element;
            }
        }
        public void Open() {
            CloseDrawerButton.SetActive(true);
            RectTransform.anchoredPosition = new Vector2(RectTransform.anchoredPosition.x, 800);
            DrawerButton.SetActive(false);
        }

        public void Close(){
            CloseDrawerButton.SetActive(false);
            RectTransform.anchoredPosition = new Vector2(RectTransform.anchoredPosition.x, 0);
            DrawerButton.SetActive(true);
        }
        
    }
}
