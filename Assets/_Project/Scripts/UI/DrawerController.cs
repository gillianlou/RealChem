using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RealChem.UI
{
    public class DrawerController : MonoBehaviour
    {
        [SerializeField]
        private GameObject closeDrawerButton;
        [SerializeField]
        private GameObject drawerButton;
        private RectTransform RectTransform => transform as RectTransform;
        public void Open() {
            closeDrawerButton.SetActive(true);
            RectTransform.anchoredPosition = new Vector2(RectTransform.anchoredPosition.x, 800);
            drawerButton.SetActive(false);
        }

        public void Close(){
            closeDrawerButton.SetActive(false);
            RectTransform.anchoredPosition = new Vector2(RectTransform.anchoredPosition.x, 0);
            drawerButton.SetActive(true);
        }
        
    }
}
